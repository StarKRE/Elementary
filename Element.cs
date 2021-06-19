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
        private HashSet<IElement> childElements;

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
            if (this.childElements != null)
            {
                foreach (var element in this.childElements)
                {
                    element.OnPrepare();
                }
            }

            this.OnPrepare();
        }

        ///<inheritdoc cref="IElement.OnPrepare"/>
        protected virtual void OnPrepare()
        {
        }

        void IElement.OnReady()
        {
            if (this.childElements != null)
            {
                foreach (var element in this.childElements)
                {
                    element.OnReady();
                }
            }

            this.OnReady();
        }

        ///<inheritdoc cref="IElement.OnReady"/>
        protected virtual void OnReady()
        {
        }

        void IElement.OnStart()
        {
            if (this.childElements != null)
            {
                foreach (var element in this.childElements)
                {
                    element.OnStart();
                }
            }

            this.OnStart();
        }

        /// <inheritdoc cref="IElement.OnStart"/>
        protected virtual void OnStart()
        {
        }

        void IElement.OnFinish()
        {
            if (this.childElements != null)
            {
                foreach (var element in this.childElements)
                {
                    element.OnFinish();
                }
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

            if (this.childElements != null)
            {
                foreach (var element in this.childElements)
                {
                    element.OnDispose();
                }

                this.childElements = null;
            }
        }

        ///<inheritdoc cref="IElement.OnDispose"/>
        protected virtual void OnDispose()
        {
        }

        #endregion

        ///<inheritdoc cref="IElementContext.CreateElement"/>
        protected T CreateElement<T>()
        {
            if (this.childElements == null)
            {
                this.childElements = new HashSet<IElement>();
            }

            var newElement = this.context.CreateElement<T>();
            this.childElements.Add((IElement) newElement);
            return newElement;
        }

        ///<inheritdoc cref="IElementContext.CreateElements"/>
        protected IEnumerable<T> CreateElements<T>()
        {
            if (this.childElements == null)
            {
                this.childElements = new HashSet<IElement>();
            }

            var newElements = this.context.CreateElements<T>();
            foreach (var element in newElements)
            {
                this.childElements.Add((IElement) element);
            }

            return newElements;
        }

        ///<inheritdoc cref="IElementContext.GetRootElement"/>
        protected T GetRootElement<T>()
        {
            return this.context.GetRootElement<T>();
        }

        ///<inheritdoc cref="IElementContext.GetRootElements"/>
        protected IEnumerable<T> GetRootElements<T>()
        {
            return this.context.GetRootElements<T>();
        }
    }
}