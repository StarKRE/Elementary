namespace OregoFramework.Client
{
    public interface IResetObserverNetworkManager : INetworkManager
    {
        void AddOnResetManaListener(IOnResetNetworkManagerListener listener);

        void RemoveOnResetListener(IOnResetNetworkManagerListener listener);
    }

    public interface IOnResetNetworkManagerListener
    {
        void OnReset(INetworkManager networkManager);
    }
}