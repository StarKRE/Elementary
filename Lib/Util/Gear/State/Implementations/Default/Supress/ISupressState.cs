namespace OregoFramework.Util
{
    public interface ISupressState : IState
    {
        IState OnSupress(IState nextState);
    }
}