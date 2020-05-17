using System.Collections;
using OregoFramework.Core;

namespace OregoFramework.Client
{
    public abstract class OregoNetworkManager : OregoComponent, IOregoNetworkManager
    {
        public IEnumerator SendRequestTask(OregoRequestTask requestTask)
        {
            yield return OnBeforeRequestTask(requestTask);
            yield return requestTask.unityWebRequest.SendWebRequest();
            yield return this.OnAfterRequestTask(requestTask);
        }

        protected virtual IEnumerator OnBeforeRequestTask(OregoRequestTask requestTask)
        {
            yield break;
        }

        protected virtual IEnumerator OnAfterRequestTask(OregoRequestTask requestTask)
        {
            yield break;
        }

        public virtual void Reset()
        {
        }
    }
}