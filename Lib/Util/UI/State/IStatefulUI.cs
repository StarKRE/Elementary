namespace OregoFramework.UI
{
    public interface IStatefulUI
    {
        void OnEnterState(IUIState state);

        IUIState OnExitState();
    }
}