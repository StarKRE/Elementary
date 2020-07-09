using OregoFramework.App;
using OregoFramework.Core;
using OregoFramework.Util;

namespace OregoFramework.Service
{
    /// <summary>
    /// <para>Experimental.</para>
    /// </summary>
    public abstract class Service : AutoMonoBehaviour, IElement
    {
        private IApplication _application;

        private IApplication application
        {
            get
            {
                if (this._application == null)
                {
                    this._application = Orego
                        .GetObject<IApplication>(nameof(IApplication));
                }

                return this._application;
            }
        }
        
        protected T GetApplication<T>() where T : IApplication
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

        public virtual void OnFinish()
        {
        }

        void IElement.OnDestroy()
        {
        }
    }
}