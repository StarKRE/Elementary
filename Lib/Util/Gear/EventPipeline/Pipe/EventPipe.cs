using System.Collections.Generic;

namespace OregoFramework.Util.Gear
{
    public abstract class EventPipe : AutoMonoBehaviour, IEventPipe
    {
        public List<IEventHandler> handlerSequence { get; }

        protected EventPipe()
        {
            this.handlerSequence = new List<IEventHandler>();
        }

        #region PushEvent

        protected abstract bool MatchesEvent(IEvent inputEvent);

        public IEvent PushEvent(IEvent inputEvent)
        {
            if (!this.MatchesEvent(inputEvent))
            {
                return inputEvent;
            }

            var index = Int.ZERO;
            while (index < this.handlerSequence.Count)
            {
                var handler = this.handlerSequence[index++];
                if (!handler.isEnabled)
                {
                    continue;
                }

                inputEvent = handler.HandleEvent(inputEvent);
                if (inputEvent == null)
                {
                    return this.GetDefaultEvent();
                }
            }

            return inputEvent;
        }

        protected virtual IEvent GetDefaultEvent()
        {
            return null;
        }

        #endregion
    }
}