using System.Collections.Generic;

namespace OregoFramework.Util.Gear
{
    public abstract class CustomBaseEventPipedHandler<TEventPipetId, TEvent> :
        BaseEventPipedHandler<TEventPipetId, TEvent>
        where TEvent : IEvent
    {
        public override void OnCreate()
        {
            base.OnCreate();
            var pipeAssets = this.LoadEventPipeAssets();
            foreach (var asset in pipeAssets)
            {
                var eventPipe = this.New(asset);
                this.BindPipe(eventPipe);
            }
        }

        protected abstract IEnumerable<EventPipe> LoadEventPipeAssets();
    }
}