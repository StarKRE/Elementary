using System.Collections;

namespace ElementaryFramework.App
{
    public interface INetworkManager
    {
        IEnumerator SendRequestTask(RequestTask requestTask);

        void Reset();
    }
}