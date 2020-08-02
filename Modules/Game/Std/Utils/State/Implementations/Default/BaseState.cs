namespace ElementaryFramework.Util
{
    public class BaseState : State
    {
        private readonly object parent;

        public BaseState(object parent)
        {
            this.parent = parent;
        }

        protected T GetParent<T>()
        {
            return (T) this.parent;
        }
    }
}