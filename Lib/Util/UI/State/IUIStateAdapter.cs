namespace OregoFramework.UI
{
    public interface IUIStateAdapter
    {
        IUIState Get();

        void Set(IUIState state);
    }
}