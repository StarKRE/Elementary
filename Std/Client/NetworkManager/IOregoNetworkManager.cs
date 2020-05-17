using System.Collections;

namespace OregoFramework.Client
{
    public interface IOregoNetworkManager
    {
        IEnumerator SendRequestTask(OregoRequestTask requestTask);

        void Reset();
    }
}