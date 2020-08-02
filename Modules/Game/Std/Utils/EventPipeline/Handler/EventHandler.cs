namespace ElementaryFramework.Util.Gear
{
    public abstract class EventHandler : AutoMonoBehaviour, IEventHandler
    {
        public virtual bool isEnabled { get; set; } = true;

        protected abstract bool MatchesEvent(IEvent inputEvent);

        public IEvent HandleEvent(IEvent inputEvent)
        {
            if (this.MatchesEvent(inputEvent))
            {
                return this.OnHandleEvent(inputEvent);
            }

            return inputEvent;
        }

        protected abstract IEvent OnHandleEvent(IEvent inputEvent);
    }
}