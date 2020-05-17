using System.Collections.Generic;

namespace OregoFramework.Util.Gear
{
    public abstract class CustomBaseEventPipe<E> : BaseEventPipe<E>
        where E : IEvent
    {
        public override void OnCreate()
        {
            base.OnCreate();
            var eventHandlerAssets = this.LoadEventHandlerAssets();
            foreach (var handlerAsset in eventHandlerAssets)
            {
                var handler = this.New(handlerAsset);
                this.handlerSequence.Add(handler);
            }
        }

        protected abstract IEnumerable<EventHandler> LoadEventHandlerAssets();
    }
}