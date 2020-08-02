using System.Collections;
using UnityEngine.Networking;

namespace ElementaryFramework.App
{
    public abstract class BaseCaller : Caller<IBaseClient> 
    {
        private INetworkManager networkManager;

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.networkManager = this.parentClient.GetNetworkManager<INetworkManager>();
        }
        
        protected IEnumerator SendRequest(UnityWebRequest webRequest)
        {
            var requestTask = new RequestTask(webRequest);
            yield return this.networkManager.SendRequestTask(requestTask);
        }
    }
}