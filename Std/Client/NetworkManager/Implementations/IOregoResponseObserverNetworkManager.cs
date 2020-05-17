using System.Collections;

namespace OregoFramework.Client
{
    public interface IOregoResponseObserverNetworkManager : IOregoNetworkManager
    {
        void AddOnResponseListener(IOregoOnResponseRequestTaskListener listener);

        void RemoveOnResponseListener(IOregoOnResponseRequestTaskListener listener);
    }

    public interface IOregoOnResponseRequestTaskListener
    {
        IEnumerator OnResponse(IOregoNetworkManager networkManager, OregoRequestTask request);
    }
}