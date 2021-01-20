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
        ///     <para>Keeps interface type vs specific types.</para>
        /// </summary>
        protected Dictionary<Type, HashSet<Type>> InheritanceTable { get; private set; }

        private Dictionary<Type, IRootElement> rootElementMap;

        /// <inheritdoc cref="IElementContext.Initialize"/>
        public void Initialize()
        {
            this.InheritanceTable = this.ProvideInheritanceTable();
            this.InstantiateElements();
        }

        /// <inheritdoc cref="IElementContext.Terminate"/>
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

        ///<inheritdoc cref="IElementContext.CreateElement"/>
        public T CreateElement<T>(Type implementationType) where T : IElement
        {
            var baseType = typeof(T);
            if (this.InheritanceTable.ContainsKey(baseType) &&
                this.InheritanceTable[baseType].Contains(implementationType))
            {
                return this.CreateInstance<T>(implementationType);
            }

            if (this.InheritanceTable.ContainsKey(elementType) &&
                this.InheritanceTable[elementType].Contains(implementationType))
            {
                return this.CreateInstance<T>(implementationType);
            }

            var message = string.Format(TYPE_NOT_FOUND_MESSAGE, implementationType.Name);
            throw new Exception(message);
        }

        ///<inheritdoc cref="IElementContext.CreateElements"/>
        public IEnumerable<T> CreateElements<T>() where T : IElement
        {
            var newElements = new HashSet<T>();
            var baseType = typeof(T);
            if (!this.InheritanceTable.ContainsKey(baseType))
            {
                return newElements;
            }

            var derivedTypes = this.InheritanceTable[baseType];
            foreach (var type in derivedTypes)
            {
                var newElement = this.CreateInstance<T>(type);
                newElements.Add(newElement);
            }

            return newElements;
        }

        ///<inheritdoc cref="IElementContext.GetRootElement"/>
        public T GetRootElement<T>() where T : IRootElement
        {
            return this.rootElementMap.Find<T, IRootElement>();
        }

        ///<inheritdoc cref="IElementContext.GetRootElements"/>
        public IEnumerable<T> GetRootElements<T>() where T : IRootElement
        {
            return this.rootElementMap.Values.OfType<T>();
        }

        /// <summary>
        ///      <para>Returns an dictionary: interface vs specific types.</para>
        /// </summary>
        protected virtual Dictionary<Type, HashSet<Type>> ProvideInheritanceTable()
        {
            var tableBuilder = new ElementTypeDictionaryBuilder();
            var derivedTypeDictionary = tableBuilder.Build();
            return derivedTypeDictionary;
        }

        /// <summary>
        ///     <para>Instantiates a new instance by type.</para>
        /// </summary>
        protected virtual T NewInstance<T>(Type specificType)
        {
            return (T) Activator.CreateInstance(specificType);
        }

        private T CreateInstance<T>(Type type) where T : IElement
        {
            var element = this.NewInstance<T>(type);
            element.OnCreate(this);
            return element;
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
    }
}