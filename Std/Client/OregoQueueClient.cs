using System.Collections.Generic;

namespace OregoFramework.Client
{
    public abstract class OregoQueueClient<T> : OregoBaseClient<T> where T : OregoBaseCaller
    {
        #region OnCreate

        protected sealed override IOregoNetworkManager LoadNetworkManager()
        {
            return this.LoadQueueNetworkManager();
        }

        protected abstract OregoQueueNetworkManager LoadQueueNetworkManager();

        #endregion

        #region OnPrepare

        public override void OnPrepare()
        {
            base.OnPrepare();
            var networkManager = this.GetNetworkManager<OregoQueueNetworkManager>();
            var onResponseRequestTaskListeners = this.GetOnResponseRequestTaskListeners();
            foreach (var onResponseRequestTaskListener in onResponseRequestTaskListeners)
            {
                networkManager.AddOnResponseListener(onResponseRequestTaskListener);
            }

            var onResetNetworkManagerListeners = this.GetOnResetNetworkManagerListeners();
            foreach (var onResetNetworkManagerListener in onResetNetworkManagerListeners)
            {
                networkManager.AddOnResetManaListener(onResetNetworkManagerListener);
            }
        }

        protected virtual IEnumerable<IOregoOnResponseRequestTaskListener> GetOnResponseRequestTaskListeners()
        {
            return new IOregoOnResponseRequestTaskListener[]{};
        }

        protected virtual IEnumerable<IOregoOnResetNetworkManagerListener> GetOnResetNetworkManagerListeners()
        {
            return new IOregoOnResetNetworkManagerListener[]{};
        }

        #endregion
    }
}