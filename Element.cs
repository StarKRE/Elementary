using System.Collections.Generic;

namespace Elementary
{
    /// <summary>
    ///     <para>A base element class.</para>
    /// </summary>
    public abstract class Element : IElement
    {
        /// <summary>
        ///     <para>A element context reference that created this element.</para>
        /// </summary>
        private IElementContext context;

        /// <summary>
        ///     <para>Elements instantiated by this element.</para>
        /// </summary>
        private readonly HashSet<IElement> childElements;

        /// <summary>
        ///     <para>Any element should only contain a default constructor.</para>
        /// </summary>
        protected Element()
        {
            this.childElements = new HashSet<IElement>();
        }

        #region Lifecycle

        void IElement.OnCreate(IElementContext context)
        {
            this.context = context;
            this.OnCreate();
        }

        ///<inheritdoc cref="IElement.OnCreate"/>
        protected virtual void OnCreate()
        {
        }

        void IElement.OnPrepare()
        {
            foreach (var element in this.childElements)
            {
                element.OnPrepare();
            }

            this.OnPrepare();
        }

        ///<inheritdoc cref="IElement.OnPrepare"/>
        protected virtual void OnPrepare()
        {
        }

        void IElement.OnReady()
        {
            foreach (var element in this.childElements)
            {
                element.OnReady();
            }

            this.OnReady();
        }

        ///<inheritdoc cref="IElement.OnReady"/>
        protected virtual void OnReady()
        {
        }

        void IElement.OnStart()
        {
            foreach (var element in this.childElements)
            {
                element.OnStart();
            }

            this.OnStart();
        }

        /// <inheritdoc cref="IElement.OnStart"/>
        protected virtual void OnStart()
        {
        }

        void IElement.OnFinish()
        {
            foreach (var element in this.childElements)
            {
                element.OnFinish();
            }

            this.OnFinish();
        }

        ///<inheritdoc cref="IElement.OnFinish"/>
        protected virtual void OnFinish()
        {
        }

        void IElement.OnDispose()
        {
            this.OnDispose();
            foreach (var element in this.childElements)
            {
                element.OnDispose();
            }

            this.childElements.Clear();
        }

        ///<inheritdoc cref="IElement.OnDispose"/>
        protected virtual void OnDispose()
        {
        }

        #endregion

        ///<inheritdoc cref="IElementContext.CreateElement"/>
        protected T CreateElement<T>() where T : IElement
        {
            var newElement = this.context.CreateElement<T>();
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