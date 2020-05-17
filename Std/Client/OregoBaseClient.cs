namespace OregoFramework.Client
{
    public abstract class OregoBaseClient<T> : OregoClient<T>, IOregoBaseClient where T : IOregoCaller
    {
        private IOregoNetworkManager networkManager;

        #region OnCreate

        public sealed override void OnCreate()
        {
            base.OnCreate();
            this.networkManager = this.LoadNetworkManager();
            this.OnCreate(this);
        }

        protected abstract IOregoNetworkManager LoadNetworkManager();

        protected virtual void OnCreate(OregoBaseClient<T> self)
        {
        }

        #endregion

        public TNetworkManager GetNetworkManager<TNetworkManager>() where TNetworkManager : IOregoNetworkManager
        {
            return (TNetworkManager) this.networkManager;
        }
    }
}