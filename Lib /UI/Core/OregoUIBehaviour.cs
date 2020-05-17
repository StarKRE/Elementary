using System.Collections.Generic;
using OregoFramework.App;
using OregoFramework.Core;
using OregoFramework.Domain;
using OregoFramework.Util;

namespace OregoFramework.UI
{
    public abstract class OregoUIBehaviour : AutoMonoBehaviour
    {
        private IOregoApplication _application;

        private IOregoApplication application
        {
            get
            {
                return this._application ?? (this._application = Orego
                    .GetObject<IOregoApplication>(nameof(IOregoApplication)));
            }
        }

        private IOregoInteractorLayer _interactorLayer;

        private IOregoInteractorLayer interactorLayer
        {
            get
            {
                return this._interactorLayer ?? (this._interactorLayer = this.application
                    .GetInteractorLayer<IOregoInteractorLayer>());
            }
        }
        
        protected T GetApplication<T>() where T : IOregoApplication
        {
            return (T) this.application;
        }

        protected T GetInteractor<T>() where T : IOregoInteractor
        {
            return this.interactorLayer.GetInteractor<T>();
        }

        protected IEnumerable<T> GetInteractors<T>() where T : IOregoInteractor
        {
            return this.interactorLayer.GetInteractors<T>();
        }
    }
}