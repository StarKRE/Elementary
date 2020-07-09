using System.Collections;

namespace OregoFramework.Client
{
    public interface INetworkManager
    {
        IEnumerator SendRequestTask(RequestTask requestTask);

        void Reset();
    }
}