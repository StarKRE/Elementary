using System.Collections;

namespace ElementaryFramework.App
{
    public interface IQueueNetworkManager : INetworkManager
    {
        IEnumerator EnqueueRequestTask(RequestTask requestTask);
    }
}