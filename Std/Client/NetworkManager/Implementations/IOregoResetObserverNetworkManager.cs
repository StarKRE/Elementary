namespace OregoFramework.Client
{
    public interface IOregoResetObserverNetworkManager : IOregoNetworkManager
    {
        void AddOnResetManaListener(IOregoOnResetNetworkManagerListener listener);

        void RemoveOnResetListener(IOregoOnResetNetworkManagerListener listener);
    }

    public interface IOregoOnResetNetworkManagerListener
    {
        void OnReset(IOregoNetworkManager networkManager);
    }
}