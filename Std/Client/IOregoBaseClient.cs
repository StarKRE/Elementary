namespace OregoFramework.Client
{
    public interface IOregoBaseClient : IOregoClient
    {
        TNetworkManager GetNetworkManager<TNetworkManager>() where TNetworkManager : IOregoNetworkManager;
    }
}