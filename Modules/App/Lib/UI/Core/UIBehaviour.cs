using System.Collections.Generic;
using ElementaryFramework.Core;
using ElementaryFramework.Util;

namespace ElementaryFramework.App
{
    public abstract class UIBehaviour : AutoMonoBehaviour
    {
        private IApplication _application;

        private IApplication application
        {
            get
            {
                if (this._application == null)
                {
                    var context = Elementary.GetCore<IElementContext>();
                    this._application = context.GetRoot<IApplication>();
                }

                return this._application;
            }
        }

        private IInteractorLayer _interactorLayer;

        private IInteractorLayer interactorLayer
        {
            get
            {
                if (this._interactorLayer == null)
                {
                    this._interactorLayer = this.application.interactorLayer;
                }

                return this._interactorLayer;
            }
        }

        protected T GetApplication<T>() where T : IApplication
        {
            return (T) this.application;
        }

        protected T GetInteractor<T>() where T : IInteractor
        {
            return this.interactorLayer.GetInteractor<T>();
        }

        protected IEnumerable<T> GetInteractors<T>() where T : IInteractor
        {
            return this.interactorLayer.GetInteractors<T>();
        }
    }
}