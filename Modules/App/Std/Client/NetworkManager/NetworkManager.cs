using System.Collections;
using ElementaryFramework.Core;

namespace ElementaryFramework.App
{
    public abstract class NetworkManager : Element, INetworkManager
    {
        public IEnumerator SendRequestTask(RequestTask requestTask)
        {
            yield return OnBeforeRequestTask(requestTask);
            yield return requestTask.unityWebRequest.SendWebRequest();
            yield return this.OnAfterRequestTask(requestTask);
        }

        protected virtual IEnumerator OnBeforeRequestTask(RequestTask requestTask)
        {
            yield break;
        }

        protected virtual IEnumerator OnAfterRequestTask(RequestTask requestTask)
        {
            yield break;
        }

        public virtual void Reset()
        {
        }
    }
}