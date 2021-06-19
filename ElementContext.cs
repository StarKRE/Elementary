using System;
using System.Collections.Generic;
using System.Linq;

namespace Elementary
{
    /// <summary>
    ///     <para>A base element context.</para>
    /// </summary>
    public sealed class ElementContext : IElementContext, IDisposable
    {
        private readonly Dictionary<Type, HashSet<Type>> inheritanceTable;

        private readonly Dictionary<Type, IRootElement> rootElementMap;

        public ElementContext() : this(new TypeDictionaryBuilder())
        {
        }

        public ElementContext(ITypeDictionaryBuilder builder) : this(builder.Build())
        {
        }

        /// <summary>
        ///     <para>Creates root elements.</para>
        /// </summary>
        /// <param name="inheritanceTable">Dictionary of abstract type vs implementation types.</param>
        public ElementContext(Dictionary<Type, HashSet<Type>> inheritanceTable)
        {
            this.inheritanceTable = inheritanceTable;
            this.rootElementMap = new Dictionary<Type, IRootElement>();

            var rootElements = this.CreateElements<IRootElement>();
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

        /// <summary>
        ///     <para>Finalizes root elements.</para>
        /// </summary>
        public void Dispose()
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
        public T CreateElement<T>()
        {
            var baseType = typeof(T);
            if (!this.inheritanceTable.TryGetValue(baseType, out var derivedTypes) ||
                derivedTypes.Count == 0)
            {
                throw new NoImplementationException(baseType);
            }

            if (derivedTypes.Count > 1)
            {
                throw new SeveralImplementationsException(baseType, derivedTypes);
            }

            Type targetType;
            using (var enumerator = derivedTypes.GetEnumerator())
            {
                enumerator.MoveNext();
                targetType = enumerator.Current;
            }

            return this.CreateInstance<T>(targetType);
        }

        ///<inheritdoc cref="IElementContext.CreateElements"/>
        public IEnumerable<T> CreateElements<T>()
        {
            var baseType = typeof(T);
            if (!this.inheritanceTable.ContainsKey(baseType))
            {
                return new T[0];
            }

            var derivedTypes = this.inheritanceTable[baseType];
            var result = new T[derivedTypes.Count];

            var index = 0;
            foreach (var type in derivedTypes)
            {
                var newElement = this.CreateInstance<T>(type);
                result[index] = newElement;
                index++;
            }

            return result;
        }

        ///<inheritdoc cref="IElementContext.GetRootElement"/>
        public T GetRootElement<T>()
        {
            return this.rootElementMap.Find<T, IRootElement>();
        }

        ///<inheritdoc cref="IElementContext.GetRootElements"/>
        public IEnumerable<T> GetRootElements<T>()
        {
            return this.rootElementMap.Values.OfType<T>();
        }

        private T CreateInstance<T>(Type type)
        {
            var element = (IElement) Activator.CreateInstance(type);
            element.OnCreate(this);
            return (T) element;
        }
    }
}