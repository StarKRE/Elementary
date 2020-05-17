namespace OregoFramework.Util
{
    public abstract class BaseScriptableState<T> : ScriptableState, IScriptableParentState
    {
        protected T parent { get; private set; }

        public void BindParent(object parent)
        {
            this.parent = (T) parent;
            this.OnBindParent();
        }

        protected virtual void OnBindParent()
        {
        }
    }
}