using System;
using System.Collections.Generic;
using OregoFramework.Util;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Implements system layer of elements in the framework.</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ElementLayer<T> : Element
        where T : IElement
    {
        private readonly Dictionary<Type, T> childElementMap;

        protected ElementLayer()
        {
            this.childElementMap = new Dictionary<Type, T>();
        }

        protected IEnumerable<T> allElements
        {
            get { return this.childElementMap.Values; }
        }

        protected IEnumerable<E> GetElements<E>() where E : T
        {
            return this.childElementMap.FindAll<E, T>();
        }

        protected E GetElement<E>() where E : T
        {
            return this.childElementMap.Find<E, T>();
        }
        
        protected T this[Type elementType]
        {
            get { return this.childElementMap.Find(elementType); }
        }

        public override void OnCreate()
        {
            var childElements = this.CreateElements<T>();
            foreach (var childElement in childElements)
            {
                this.childElementMap.AddByType(childElement);
            }
        }

        public override void OnDestroy()
        {
            this.childElementMap.Clear();
            base.OnDestroy();
        }
    }
}