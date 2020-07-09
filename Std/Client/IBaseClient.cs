namespace OregoFramework.Client
{
    public interface IBaseClient : IClient
    {
        TNetworkManager GetNetworkManager<TNetworkManager>() where TNetworkManager : INetworkManager;
    }
}