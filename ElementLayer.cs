using System;
using System.Collections.Generic;
using System.Linq;

namespace Elementary
{
    /// <summary>
    ///    <para>Keeps a element group of "T" type.</para>
    ///    <para>The group consists of unique elements derived from "T".</para>
    ///    <para>Use this class to create a new architecture layer of your application.</para>
    /// </summary>
    /// <typeparam name="T">Base element type.</typeparam>
    public abstract class ElementLayer<T> : Element where T : IElement
    {
        /// <summary>
        ///     <para>Dictionary of unique elements derived from "T".</para>
        /// </summary>
        private readonly Dictionary<Type, T> elementMap;

        /// <summary>
        ///     <para>Any derived element must contains only default constructor.</para>
        /// </summary>
        protected ElementLayer()
        {
            this.elementMap = new Dictionary<Type, T>();
        }

        /// <summary>
        ///     <para>Returns a unique element from the dictionary.</para>
        /// </summary>
        /// 
        /// <typeparam name="E">Type of element.</typeparam>
        /// <returns>Element instance of the specified type.</returns>
        protected E GetElement<E>()
        {
            return this.elementMap.Find<E, T>();
        }

        /// <summary>
        ///     <para>Returns a group of unique elements derived from "E".</para>
        /// </summary>
        /// 
        /// <typeparam name="E">Base type of elements.</typeparam>
        /// <returns>Element instances from the dictionary.</returns>
        protected IEnumerable<E> GetElements<E>()
        {
            return this.elementMap.Values.OfType<E>();
        }

        /// <inheritdoc cref="IElement.OnCreate"/>
        protected sealed override void OnCreate(Element _, IElementContext context)
        {
            var elements = this.CreateElements<T>();
            foreach (var element in elements)
            {
                var type = element.GetType();
                this.elementMap.Add(type, element);
            }

            this.OnCreate(this, context);
        }

        protected virtual void OnCreate(ElementLayer<T> _, IElementContext context)
        {
        }

        /// <inheritdoc cref="IElement.OnDispose"/>
        protected sealed override void OnDispose(Element _)
        {
            this.elementMap.Clear();
            this.OnDispose(this);
        }

        protected virtual void OnDispose(ElementLayer<T> _)
        {
        }
    }
}