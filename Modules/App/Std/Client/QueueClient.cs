using System.Collections.Generic;

namespace ElementaryFramework.App
{
    public abstract class QueueClient<T> : BaseClient<T> where T : BaseCaller
    {
        #region OnCreate

        protected sealed override INetworkManager LoadNetworkManager()
        {
            return this.LoadQueueNetworkManager();
        }

        protected abstract QueueNetworkManager LoadQueueNetworkManager();

        #endregion

        #region OnPrepare

        public override void OnPrepare()
        {
            base.OnPrepare();
            var networkManager = this.GetNetworkManager<QueueNetworkManager>();
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

        protected virtual IEnumerable<IOnResponseRequestTaskListener>
            GetOnResponseRequestTaskListeners()
        {
            return new IOnResponseRequestTaskListener[] { };
        }

        protected virtual IEnumerable<IOnResetNetworkManagerListener>
            GetOnResetNetworkManagerListeners()
        {
            return new IOnResetNetworkManagerListener[] { };
        }

        #endregion
    }
}