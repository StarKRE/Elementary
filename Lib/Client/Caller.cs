using OregoFramework.App;
using OregoFramework.Core;

namespace OregoFramework.Client
{
    /// <summary>
    ///     <para>Base abstract implementation of caller interface.</para>
    /// </summary>
    public abstract class Caller<T> : Element, ICaller where T : IClient
    {
        protected T parentClient { get; private set; }

        private IApplication application;

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = Orego.GetObject<IApplication>(nameof(IApplication));
            var clientLayer = this.application.GetClientLayer<IClientLayer>();
            this.parentClient = clientLayer.GetClient<T>();
        }

        protected TApplication GetApplication<TApplication>() where TApplication : IApplication
        {
            return (TApplication) this.application;
        }
    }
}