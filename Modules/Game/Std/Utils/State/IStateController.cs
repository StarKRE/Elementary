namespace ElementaryFramework.Util
{
    public interface IStateController
    {
        AutoEvent<IState> OnStateChangedEvent { get; }

        T GetCurrentState<T>() where T : IState;

        void SetCurrentState(IState nextState);
    }
}