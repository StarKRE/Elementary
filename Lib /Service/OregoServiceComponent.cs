using OregoFramework.App;
using OregoFramework.Core;
using OregoFramework.Util;

namespace OregoFramework.Service
{
    /// <summary>
    /// <para>Experimental.</para>
    /// </summary>
    public abstract class OregoServiceComponent : AutoMonoBehaviour, IOregoComponent
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
        
        protected T GetApplication<T>() where T : IOregoApplication
        {
            return (T) this.application;
        }
        
        public virtual void OnCreate()
        {
        }

        public virtual void OnPrepare()
        {
        }

        public virtual void OnReady()
        {
        }

        public virtual void OnStart()
        {
        }

        public virtual void OnStop()
        {
        }

        void IOregoComponent.OnDestroy()
        {
        }
    }
}