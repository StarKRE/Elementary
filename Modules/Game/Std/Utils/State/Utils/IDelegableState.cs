namespace ElementaryFramework.Util
{
    public interface IDelegableState : IState 
    {
        void OnProvideParent(object parent);
    }
}