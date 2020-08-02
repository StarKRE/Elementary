namespace ElementaryFramework.App
{
    public interface IUIStateAdapter
    {
        IUIState Get();

        void Set(IUIState state);
    }
}