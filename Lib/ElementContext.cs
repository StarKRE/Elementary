using System;
using System.Collections.Generic;
using System.Linq;

namespace Elementary
{
    /// <summary>
    /// <para>Main class</para>
    /// </summary>
    public class ElementContext : IElementContext
    {
        private const string TYPE_NOT_FOUND_MESSAGE =
            "{0} is absent in element context! Didn't you forget to" +
            " add attribute [Using] over required class?";

        private static readonly Type elementType = typeof(IElement);

        /// <summary>
        ///      <para>Builds the two next tables.</para>
        /// </summary>
        protected virtual IElementTableBuilder TableBuilder { get; } = new ElementTableBuilder();

        /// <summary>
        ///     <para>Keeps type vs parent types.</para>
        /// </summary>
        protected Dictionary<Type, HashSet<Type>> ParentTable { get; private set; }
        
        /// <summary>
        ///     <para>Keeps type vs child types.</para>
        /// </summary>
        protected Dictionary<Type, HashSet<Type>> ChildTable { get; private set; }

        private Dictionary<Type, IRootElement> rootElementMap;

        public void Initialize()
        {
            var elementTables = this.TableBuilder.BuildElementTables();
            this.ChildTable = elementTables.ChildTable;
            this.ParentTable = elementTables.ParentTable;
            this.CreateRootElements();
        }

        private void CreateRootElements()
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

        public T CreateElement<T>(Type targetType) where T : IElement
        {
            var parentType = typeof(T);
            if (this.ChildTable.TryGetValue(parentType, out var childTypes) &&
                childTypes.Contains(targetType))
            {
                return this.CreateInstance<T>(targetType);
            }

            if (this.ChildTable.TryGetValue(elementType, out var elementTypes) &&
                elementTypes.Contains(targetType))
            {
                return this.CreateInstance<T>(targetType);
            }

            var message = string.Format(TYPE_NOT_FOUND_MESSAGE, targetType.Name);
            throw new Exception(message);
        }

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

        public T GetRootElement<T>() where T : IRootElement
        {
            return this.rootElementMap.Find<T, IRootElement>();
        }

        public IEnumerable<T> GetRootElements<T>() where T : IRootElement
        {
            return this.rootElementMap.Values.OfType<T>();
        }
    }
}