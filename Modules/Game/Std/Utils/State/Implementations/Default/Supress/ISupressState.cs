namespace ElementaryFramework.Util
{
    public interface ISupressState : IState
    {
        IState OnSupress(IState nextState);
    }
}