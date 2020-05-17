namespace OregoFramework.Util
{
    public class BaseState<T> : State
    {
        protected T parent { get; }

        public BaseState(T parent)
        {
            this.parent = parent;
        }
    }
}