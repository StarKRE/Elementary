using System.Collections;
using UnityEngine.Networking;

namespace OregoFramework.Client
{
    public abstract class OregoQueueCaller : OregoBaseCaller
    {
        private IOregoQueueNetworkManager networkManager;

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.networkManager = this.parentClient.GetNetworkManager<IOregoQueueNetworkManager>();
        }

        protected IEnumerator EnqueueRequest(UnityWebRequest webRequest)
        {
            var requestTask = new OregoRequestTask(webRequest);
            yield return this.networkManager.EnqueueRequestTask(requestTask);
        }
    }
}