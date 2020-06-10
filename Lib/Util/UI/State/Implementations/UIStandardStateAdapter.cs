namespace OregoFramework.UI
{
    public abstract class UIStandardStateAdapter<T> : IUIStateAdapter where T : IUIState
    {
        protected T state { get; set; }

        public IUIState Get()
        {
            if (this.state == null)
            {
                this.state = this.CreateState();
            }

            return this.state;
        }

        protected abstract T CreateState();

        public void Set(IUIState state)
        {
            this.state = (T) state;
        }
    }
}