using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        public T CreateElement<T>() where T : IElement
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

            using (var enumerator = derivedTypes.GetEnumerator())
            {
                enumerator.MoveNext();
                return this.CreateInstance<T>(enumerator.Current);
            }
        }

        ///<inheritdoc cref="IElementContext.CreateElements"/>
        public IEnumerable<T> CreateElements<T>() where T : IElement
        {
            var baseType = typeof(T);
            if (!this.inheritanceTable.ContainsKey(baseType))
            {
                return new HashSet<T>();
            }

            var newElements = new HashSet<T>();
            var derivedTypes = this.inheritanceTable[baseType];
            foreach (var type in derivedTypes)
            {
                var newElement = this.CreateInstance<T>(type);
                newElements.Add(newElement);
            }

            return newElements;
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

        private T CreateInstance<T>(Type type) where T : IElement
        {
            var element = (T) Activator.CreateInstance(type);
            element.OnCreate(this);
            return element;
        }
    }
}