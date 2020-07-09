using System.Collections.Generic;
using OregoFramework.App;
using OregoFramework.Core;
using OregoFramework.Domain;
using OregoFramework.Util;

namespace OregoFramework.UI
{
    public abstract class UIBehaviour : AutoMonoBehaviour
    {
        private IApplication _application;

        private IApplication application
        {
            get
            {
                return this._application ?? (this._application = Orego
                    .GetObject<IApplication>(nameof(IApplication)));
            }
        }

        private IInteractorLayer _interactorLayer;

        private IInteractorLayer interactorLayer
        {
            get
            {
                return this._interactorLayer ?? (this._interactorLayer = this.application
                    .GetInteractorLayer<IInteractorLayer>());
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