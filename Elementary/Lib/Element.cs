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

        public void OnCreate(IElementContext context)
        {
            this.context = context;
            this.OnCreate(this, context);
        }

        protected virtual void OnCreate(Element _, IElementContext context)
        {
        }

        public void OnPrepare()
        {
            foreach (var element in this.createdElements)
            {
                element.OnPrepare();
            }

            this.OnPrepare(this);
        }

        protected virtual void OnPrepare(Element _)
        {
        }

        public void OnReady()
        {
            foreach (var element in this.createdElements)
            {
                element.OnReady();
            }

            this.OnReady(this);
        }

        protected virtual void OnReady(Element _)
        {
        }

        public void OnStart()
        {
            foreach (var element in this.createdElements)
            {
                element.OnStart();
            }

            this.OnStart(this);
        }

        protected virtual void OnStart(Element _)
        {
        }

        public void OnFinish()
        {
            foreach (var element in this.createdElements)
            {
                element.OnFinish();
            }

            this.OnFinish(this);
        }

        protected virtual void OnFinish(Element _)
        {
        }

        public void OnDispose()
        {
            foreach (var element in this.createdElements)
            {
                element.OnDispose();
            }

            this.createdElements.Clear();
            this.OnDispose(this);
        }

        protected virtual void OnDispose(Element _)
        {
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