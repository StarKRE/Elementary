using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ElementaryFramework.App
{
    public abstract class BaseNetworkManager : NetworkManager,
        IResponseObserverNetworkManager,
        IResetObserverNetworkManager
    {
        private readonly HashSet<IOnResponseRequestTaskListener> onResponseListeners;

        private readonly HashSet<IOnResetNetworkManagerListener> onResetListeners;

        protected BaseNetworkManager()
        {
            this.onResponseListeners = new HashSet<IOnResponseRequestTaskListener>();
            this.onResetListeners = new HashSet<IOnResetNetworkManagerListener>();
        }

        protected sealed override IEnumerator OnAfterRequestTask(RequestTask requestTask)
        {
            var listeners = this.onResponseListeners.ToList();
            foreach (var listener in listeners)
            {
                yield return listener.OnResponse(this, requestTask);
            }

            yield return this.OnAfterRequestTask(this, requestTask);
        }

        protected virtual IEnumerator OnAfterRequestTask(
            BaseNetworkManager self,
            RequestTask requestTask
        )
        {
            yield break;
        }

        public override void Reset()
        {
            base.Reset();
            var listeners = this.onResetListeners.ToList();
            foreach (var resetListener in listeners)
            {
                resetListener.OnReset(this);
            }
        }

        public void AddOnResponseListener(IOnResponseRequestTaskListener listener)
        {
            this.onResponseListeners.Add(listener);
        }

        public void RemoveOnResponseListener(IOnResponseRequestTaskListener listener)
        {
            this.onResponseListeners.Remove(listener);
        }

        public void AddOnResetManaListener(IOnResetNetworkManagerListener listener)
        {
            this.onResetListeners.Add(listener);
        }

        public void RemoveOnResetListener(IOnResetNetworkManagerListener listener)
        {
            this.onResetListeners.Remove(listener);
        }
    }
}