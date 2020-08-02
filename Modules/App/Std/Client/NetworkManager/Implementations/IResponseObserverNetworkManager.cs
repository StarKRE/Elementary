using System.Collections;

namespace ElementaryFramework.App
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