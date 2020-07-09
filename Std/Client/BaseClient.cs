namespace OregoFramework.Client
{
    public abstract class BaseClient<T> : Client<T>, IBaseClient where T : ICaller
    {
        private INetworkManager networkManager;

        #region OnCreate

        public sealed override void OnCreate()
        {
            base.OnCreate();
            this.networkManager = this.LoadNetworkManager();
            this.OnCreate(this);
        }

        protected abstract INetworkManager LoadNetworkManager();

        protected virtual void OnCreate(BaseClient<T> self)
        {
        }

        #endregion

        public TNetworkManager GetNetworkManager<TNetworkManager>() where TNetworkManager : INetworkManager
        {
            return (TNetworkManager) this.networkManager;
        }
    }
}