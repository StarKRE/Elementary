using System.Collections;

namespace OregoFramework.Client
{
    public interface IOregoQueueNetworkManager : IOregoNetworkManager
    {
        IEnumerator EnqueueRequestTask(OregoRequestTask requestTask);
    }
}