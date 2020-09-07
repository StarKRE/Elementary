using System;
using System.Collections.Generic;

namespace Elementary
{
    /// <summary>
    ///     <para>A base element class of element context.</para>
    /// </summary>
    public abstract class Element : IElement
    {
        /// <summary>
        ///     <para>A parent context where this element is located.</para>
        /// </summary>
        private IElementContext context;

        /// <summary>
        ///     <para>Elements those instantiated by this element.</para>
        /// </summary>
        private readonly HashSet<IElement> createdElements;

        /// <summary>
        ///     <para>Any derived element must contains only default constructor.</para>
        /// </summary>
        protected Element()
        {
            this.createdElements = new HashSet<IElement>();
        }

        #region Lifecycle

        ///<inheritdoc cref="IElement.OnCreate"/>
        public void OnCreate(IElementContext context)
        {
            this.context = context;
            this.OnCreate(this, context);
        }

        protected virtual void OnCreate(Element _, IElementContext context)
        {
        }

        ///<inheritdoc cref="IElement.OnPrepare"/>
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

        ///<inheritdoc cref="IElement.OnReady"/>
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

        /// <inheritdoc cref="IElement.OnStart"/>
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

        ///<inheritdoc cref="IElement.OnFinish"/>
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

        ///<inheritdoc cref="IElement.OnDispose"/>
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

        #endregion

        ///<inheritdoc cref="IElementContext.CreateElement"/>
        protected T CreateElement<T>(Type implementationType) where T : IElement
        {
            var element = this.context.CreateElement<T>(implementationType);
            this.createdElements.Add(element);
            return element;
        }

        ///<inheritdoc cref="IElementContext.CreateElements"/>
        protected IEnumerable<T> CreateElements<T>() where T : IElement
        {
            var elements = this.context.CreateElements<T>();
            foreach (var element in elements)
            {
                this.createdElements.Add(element);
            }

            return elements;
        }

        ///<inheritdoc cref="IElementContext.GetRootElement"/>
        protected T GetRootElement<T>() where T : IRootElement
        {
            return this.context.GetRootElement<T>();
        }

        ///<inheritdoc cref="IElementContext.GetRootElements"/>
        protected IEnumerable<T> GetRootElements<T>() where T : IRootElement
        {
            return this.context.GetRootElements<T>();
        }
    }
}