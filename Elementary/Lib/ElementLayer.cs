using System;
using System.Collections.Generic;
using System.Linq;

namespace Elementary
{
    /// <summary>
    ///     <para>A group of "T" elements.</para>
    /// </summary>
    /// <typeparam name="T">Interface type.</typeparam>
    public abstract class ElementLayer<T> : Element where T : IElement
    {
        private readonly Dictionary<Type, T> elementMap;
        
        protected ElementLayer()
        {
            this.elementMap = new Dictionary<Type, T>();
        }

        protected E GetElement<E>()
        {
            return this.elementMap.Find<E, T>();
        }

        protected IEnumerable<E> GetElements<E>()
        {
            return this.elementMap.Values.OfType<E>();
        }

        public override void OnCreate(IElementContext context)
        {
            base.OnCreate(context);
            var elements = this.CreateElements<T>();
            foreach (var element in elements)
            {
                var type = element.GetType();
                this.elementMap.Add(type, element);
            }
        }

        public override void OnDispose()
        {
            this.elementMap.Clear();
            base.OnDispose();
        }
    }
}