using System.Collections;

namespace OregoFramework.Client
{
    public interface IResponseObserverNetworkManager : INetworkManager
    {
        void AddOnResponseListener(IOnResponseRequestTaskListener listener);

        void RemoveOnResponseListener(IOnResponseRequestTaskListener listener);
    }

    public interface IOnResponseRequestTaskListener
    {
        IEnumerator OnResponse(INetworkManager networkManager, RequestTask request);
    }
}