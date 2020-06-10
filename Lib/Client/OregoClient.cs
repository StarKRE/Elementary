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
    public abstract class OregoClient<T> : OregoComponentLayer<T>, IOregoClient where T : IOregoCaller
    {
        private IOregoApplication application;

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = Orego.GetObject<IOregoApplication>(nameof(IOregoApplication));
        }

        public TCaller GetCaller<TCaller>() where TCaller : IOregoCaller
        {
            return (TCaller) (IOregoCaller) this[typeof(TCaller)];
        }

        public IEnumerable<TCaller> GetCallers<TCaller>() where TCaller : IOregoCaller
        {
            return this.allComponents.OfType<TCaller>();
        }

        protected TApplication GetApplication<TApplication>() where TApplication : IOregoApplication
        {
            return (TApplication) this.application;
        }
    }
}