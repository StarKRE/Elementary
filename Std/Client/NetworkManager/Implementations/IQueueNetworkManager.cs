using System.Collections;

namespace OregoFramework.Client
{
    public interface IQueueNetworkManager : INetworkManager
    {
        IEnumerator EnqueueRequestTask(RequestTask requestTask);
    }
}