using System;
using System.Collections.Generic;

namespace Elementary
{
    /// <summary>
    ///     <para>Base implementation of <see cref="IElement"/> in the context.</para>
    /// </summary>
    public abstract class Element : IElement
    {
        private IElementContext context;

        private readonly HashSet<IElement> createdElements;

        protected Element()
        {
            this.createdElements = new HashSet<IElement>();
        }

        public virtual void OnCreate(IElementContext context)
        {
            this.context = context;
        }

        public virtual void OnPrepare()
        {
            foreach (var element in this.createdElements)
            {
                element.OnPrepare();
            }
        }

        public virtual void OnReady()
        {
            foreach (var element in this.createdElements)
            {
                element.OnReady();
            }
        }

        public virtual void OnStart()
        {
            foreach (var element in this.createdElements)
            {
                element.OnStart();
            }
        }

        public virtual void OnFinish()
        {
            foreach (var element in this.createdElements)
            {
                element.OnFinish();
            }
        }

        public virtual void OnDispose()
        {
            foreach (var element in this.createdElements)
            {
                element.OnDispose();
            }

            this.createdElements.Clear();
        }

        protected T CreateElement<T>(Type targetType) where T : IElement
        {
            var element = this.context.CreateElement<T>(targetType);
            this.createdElements.Add(element);
            return element;
        }

        protected IEnumerable<T> CreateElements<T>() where T : IElement
        {
            var elements = this.context.CreateElements<T>();
            foreach (var element in elements)
            {
                this.createdElements.Add(element);
            }

            return elements;
        }
        
        protected T GetRootElement<T>() where T : IRootElement
        {
            return this.context.GetRootElement<T>();
        }

        protected IEnumerable<T> GetRootElements<T>() where T : IRootElement
        {
            return this.context.GetRootElements<T>();
        }
    }
}