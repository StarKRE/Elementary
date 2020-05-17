using OregoFramework.App;
using OregoFramework.Core;

namespace OregoFramework.Client
{
    /// <summary>
    ///     <para>Base abstract implementation of caller interface.</para>
    /// </summary>
    public abstract class OregoCaller<T> : OregoComponent, IOregoCaller where T : IOregoClient
    {
        protected T parentClient { get; private set; }

        private IOregoApplication application;

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = Orego.GetObject<IOregoApplication>(nameof(IOregoApplication));
            var clientLayer = this.application.GetClientLayer<IOregoClientLayer>();
            this.parentClient = clientLayer.GetClient<T>();
        }

        protected TApplication GetApplication<TApplication>() where TApplication : IOregoApplication
        {
            return (TApplication) this.application;
        }
    }
}