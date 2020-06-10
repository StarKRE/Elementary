namespace OregoFramework.Util
{
    public interface IDelegableState : IState 
    {
        void ProvideParent(object parent);
    }
}