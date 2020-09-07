using System;
using System.Collections.Generic;
using System.Linq;

namespace Elementary
{
    /// <summary>
    ///     <para>A base element context.</para>
    /// </summary>
    public class ElementContext : IElementContext
    {
        private const string TYPE_NOT_FOUND_MESSAGE =
            "{0} is absent in element context! Didn't you forget to" +
            " add attribute [Using] over required class?";

        private static readonly Type elementType = typeof(IElement);

        /// <summary>
        ///      <para>Builds two tables below: child and parent tables.</para>
        /// </summary>
        protected virtual IElementTableBuilder TableBuilder { get; } = new ElementTableBuilder();

        /// <summary>
        ///     <para>Child table. Keeps type vs child types.</para>
        /// </summary>
        protected Dictionary<Type, HashSet<Type>> ChildTable { get; private set; }

        /// <summary>
        ///     <para>Parent table. Keeps type vs parent types.</para>
        /// </summary>
        protected Dictionary<Type, HashSet<Type>> ParentTable { get; private set; }

        private Dictionary<Type, IRootElement> rootElementMap;

        /// <inheritdoc cref="IElementContext"/>
        public void Initialize()
        {
            var elementTables = this.TableBuilder.BuildElementTables();
            this.ChildTable = elementTables.ChildTable;
            this.ParentTable = elementTables.ParentTable;
            this.InstantiateElements();
        }

        private void InstantiateElements()
        {
            var rootElements = this.CreateElements<IRootElement>();
            this.rootElementMap = new Dictionary<Type, IRootElement>();
            foreach (var rootElement in rootElements)
            {
                var type = rootElement.GetType();
                this.rootElementMap.Add(type, rootElement);
            }

            foreach (var rootElement in rootElements)
            {
                rootElement.OnPrepare();
            }

            foreach (var rootElement in rootElements)
            {
                rootElement.OnReady();
            }

            foreach (var rootElement in rootElements)
            {
                rootElement.OnStart();
            }
        }

        /// <inheritdoc cref="IElementContext"/>
        public void Terminate()
        {
            var rootElements = this.rootElementMap.Values;
            foreach (var rootElement in rootElements)
            {
                rootElement.OnFinish();
            }

            foreach (var rootElement in rootElements)
            {
                rootElement.OnDispose();
            }

            this.rootElementMap.Clear();
        }

        ///<inheritdoc cref="IElementContext"/>
        public T CreateElement<T>(Type implementationType) where T : IElement
        {
            var parentType = typeof(T);
            if (this.ChildTable.TryGetValue(parentType, out var childTypes) &&
                childTypes.Contains(implementationType))
            {
                return this.CreateInstance<T>(implementationType);
            }

            if (this.ChildTable.TryGetValue(elementType, out var elementTypes) &&
                elementTypes.Contains(implementationType))
            {
                return this.CreateInstance<T>(implementationType);
            }

            var message = string.Format(TYPE_NOT_FOUND_MESSAGE, implementationType.Name);
            throw new Exception(message);
        }

        ///<inheritdoc cref="IElementContext"/>
        public IEnumerable<T> CreateElements<T>() where T : IElement
        {
            var newElements = new HashSet<T>();
            var parentType = typeof(T);
            if (!this.ChildTable.TryGetValue(parentType, out var childTypes))
            {
                return newElements;
            }

            foreach (var childType in childTypes)
            {
                var newElement = this.CreateInstance<T>(childType);
                newElements.Add(newElement);
            }

            return newElements;
        }

        private T CreateInstance<T>(Type type) where T : IElement
        {
            var element = (T) Activator.CreateInstance(type);
            element.OnCreate(this);
            return element;
        }

        ///<inheritdoc cref="IElementContext"/>
        public T GetRootElement<T>() where T : IRootElement
        {
            return this.rootElementMap.Find<T, IRootElement>();
        }

        ///<inheritdoc cref="IElementContext"/>
        public IEnumerable<T> GetRootElements<T>() where T : IRootElement
        {
            return this.rootElementMap.Values.OfType<T>();
        }
    }
}