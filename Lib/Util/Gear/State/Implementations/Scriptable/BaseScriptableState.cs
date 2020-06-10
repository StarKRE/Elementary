namespace OregoFramework.Util
{
    public abstract class BaseScriptableState : ScriptableState, IDelegableState
    {
        private object parent;

        public void ProvideParent(object parent)
        {
            this.parent = parent;
            this.OnParentProvided();
        }

        protected virtual void OnParentProvided()
        {
        }

        protected T GetParent<T>()
        {
            return (T) this.parent;
        }
    }
}