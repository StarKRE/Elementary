using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OregoFramework.Client
{
    public abstract class OregoBaseNetworkManager : OregoNetworkManager,
        IOregoResponseObserverNetworkManager,
        IOregoResetObserverNetworkManager
    {
        private readonly HashSet<IOregoOnResponseRequestTaskListener> onResponseListeners;

        private readonly HashSet<IOregoOnResetNetworkManagerListener> onResetListeners;

        protected OregoBaseNetworkManager()
        {
            this.onResponseListeners = new HashSet<IOregoOnResponseRequestTaskListener>();
            this.onResetListeners = new HashSet<IOregoOnResetNetworkManagerListener>();
        }

        protected sealed override IEnumerator OnAfterRequestTask(OregoRequestTask requestTask)
        {
            var listeners = this.onResponseListeners.ToList();
            foreach (var listener in listeners)
            {
                yield return listener.OnResponse(this, requestTask);
            }

            yield return this.OnAfterRequestTask(this, requestTask);
        }

        protected virtual IEnumerator OnAfterRequestTask(OregoBaseNetworkManager self, OregoRequestTask requestTask)
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

        public void AddOnResponseListener(IOregoOnResponseRequestTaskListener listener)
        {
            this.onResponseListeners.Add(listener);
        }

        public void RemoveOnResponseListener(IOregoOnResponseRequestTaskListener listener)
        {
            this.onResponseListeners.Remove(listener);
        }

        public void AddOnResetManaListener(IOregoOnResetNetworkManagerListener listener)
        {
            this.onResetListeners.Add(listener);
        }

        public void RemoveOnResetListener(IOregoOnResetNetworkManagerListener listener)
        {
            this.onResetListeners.Remove(listener);
        }
    }
}