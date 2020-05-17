namespace OregoFramework.Util
{
    public interface IScriptableParentState : IState 
    {
        void BindParent(object parent);
    }
}