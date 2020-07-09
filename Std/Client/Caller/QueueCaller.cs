using System.Collections;
using UnityEngine.Networking;

namespace OregoFramework.Client
{
    public abstract class QueueCaller : BaseCaller
    {
        private IQueueNetworkManager networkManager;

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.networkManager = this.parentClient.GetNetworkManager<IQueueNetworkManager>();
        }

        protected IEnumerator EnqueueRequest(UnityWebRequest webRequest)
        {
            var requestTask = new RequestTask(webRequest);
            yield return this.networkManager.EnqueueRequestTask(requestTask);
        }
    }
}