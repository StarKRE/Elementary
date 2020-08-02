namespace ElementaryFramework.App
{
    public interface IBaseClient : IClient
    {
        TNetworkManager GetNetworkManager<TNetworkManager>() where TNetworkManager : INetworkManager;
    }
}