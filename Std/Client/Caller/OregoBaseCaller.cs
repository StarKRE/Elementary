using System.Collections;
using UnityEngine.Networking;

namespace OregoFramework.Client
{
    public abstract class OregoBaseCaller : OregoCaller<IOregoBaseClient> 
    {
        private IOregoNetworkManager networkManager;

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.networkManager = this.parentClient.GetNetworkManager<IOregoNetworkManager>();
        }
        
        protected IEnumerator SendRequest(UnityWebRequest webRequest)
        {
            var requestTask = new OregoRequestTask(webRequest);
            yield return this.networkManager.SendRequestTask(requestTask);
        }
    }
}