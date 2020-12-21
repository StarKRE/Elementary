using System;
using System.Collections.Generic;

namespace Elementary
{
    /// <summary>
    ///     <para>A base element class.</para>
    /// </summary>
    public abstract class Element : IElement
    {
        /// <summary>
        ///     <para>A parent context where this element is located.</para>
        /// </summary>
        private IElementContext context;

        /// <summary>
        ///     <para>Elements instantiated by this element.</para>
        /// </summary>
        private readonly HashSet<IElement> childElements;

        /// <summary>
        ///     <para>Any derived element must contains only default constructor.</para>
        /// </summary>
        protected Element()
        {
            this.childElements = new HashSet<IElement>();
        }

        #region Lifecycle

        ///<inheritdoc cref="IElement.OnCreate"/>
        void IElement.OnCreate(IElementContext context)
        {
            this.context = context;
            this.OnCreate(this, context);
        }

        protected virtual void OnCreate(Element _, IElementContext context)
        {
        }

        ///<inheritdoc cref="IElement.OnPrepare"/>
        void IElement.OnPrepare()
        {
            foreach (var element in this.childElements)
            {
                element.OnPrepare();
            }

            this.OnPrepare(this);
        }

        protected virtual void OnPrepare(Element _)
        {
        }

        ///<inheritdoc cref="IElement.OnReady"/>
        void IElement.OnReady()
        {
            foreach (var element in this.childElements)
            {
                element.OnReady();
            }

            this.OnReady(this);
        }

        protected virtual void OnReady(Element _)
        {
        }

        /// <inheritdoc cref="IElement.OnStart"/>
        void IElement.OnStart()
        {
            foreach (var element in this.childElements)
            {
                element.OnStart();
            }

            this.OnStart(this);
        }

        protected virtual void OnStart(Element _)
        {
        }

        ///<inheritdoc cref="IElement.OnFinish"/>
        void IElement.OnFinish()
        {
            foreach (var element in this.childElements)
            {
                element.OnFinish();
            }

            this.OnFinish(this);
        }

        protected virtual void OnFinish(Element _)
        {
        }

        ///<inheritdoc cref="IElement.OnDispose"/>
        void IElement.OnDispose()
        {
            this.OnDispose(this);
            foreach (var element in this.childElements)
            {
                element.OnDispose();
            }

            this.childElements.Clear();
        }

        protected virtual void OnDispose(Element _)
        {
        }

        #endregion

        ///<inheritdoc cref="IElementContext.CreateElement"/>
        protected T CreateElement<T>(Type implementationType) where T : IElement
        {
            var newElement = this.context.CreateElement<T>(implementationType);
            this.childElements.Add(newElement);
            return newElement;
        }

        ///<inheritdoc cref="IElementContext.CreateElements"/>
        protected IEnumerable<T> CreateElements<T>() where T : IElement
        {
            var newElements = this.context.CreateElements<T>();
            foreach (var element in newElements)
            {
                this.childElements.Add(element);
            }

            return newElements;
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