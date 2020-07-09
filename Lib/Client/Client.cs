using System.Collections.Generic;
using System.Linq;
using OregoFramework.App;
using OregoFramework.Core;

namespace OregoFramework.Client
{
    /// <summary>
    ///     <para>Base abstract implementation of client interface.</para>
    /// </summary>
    /// <typeparam name="T">Requred caller type.</typeparam>
    public abstract class Client<T> : ElementLayer<T>, IClient where T : ICaller
    {
        private IApplication application;

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = Orego.GetObject<IApplication>(nameof(IApplication));
        }

        public TCaller GetCaller<TCaller>() where TCaller : ICaller
        {
            return (TCaller) (ICaller) this[typeof(TCaller)];
        }

        public IEnumerable<TCaller> GetCallers<TCaller>() where TCaller : ICaller
        {
            return this.allElements.OfType<TCaller>();
        }

        protected TApplication GetApplication<TApplication>() where TApplication : IApplication
        {
            return (TApplication) this.application;
        }
    }
}