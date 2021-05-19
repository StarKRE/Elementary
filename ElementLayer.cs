using System;
using System.Collections.Generic;
using System.Linq;

namespace Elementary
{
    /// <summary>
    ///    <para>Dictionary of unique elements derived from "T".</para>
    /// </summary>
    /// 
    /// <typeparam name="T">Type or interface.</typeparam>
    public abstract class ElementLayer<T> : Element where T : IElement
    {
        private readonly Dictionary<Type, T> elementMap;

        protected ElementLayer()
        {
            this.elementMap = new Dictionary<Type, T>();
        }

        /// <summary>
        ///     <para>Returns an element of "E".</para>
        /// </summary> 
        protected E GetElement<E>()
        {
            return this.elementMap.Find<E, T>();
        }

        /// <summary>
        ///     <para>Returns elements derived from "E".</para>
        /// </summary>
        protected IEnumerable<E> GetElements<E>()
        {
            return this.elementMap.Values.OfType<E>();
        }

        /// <inheritdoc cref="IElement.OnCreate"/>
        protected override void OnCreate()
        {
            var elements = this.CreateElements<T>();
            foreach (var element in elements)
            {
                var type = element.GetType();
                this.elementMap.Add(type, element);
            }
        }

        /// <inheritdoc cref="IElement.OnDispose"/>
        protected override void OnDispose()
        {
            this.elementMap.Clear();
        }
    }
}