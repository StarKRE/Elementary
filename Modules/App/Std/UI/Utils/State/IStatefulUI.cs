namespace ElementaryFramework.App
{
    public interface IStatefulUI
    {
        void OnEnterState(IUIState state);

        IUIState OnExitState();
    }
}