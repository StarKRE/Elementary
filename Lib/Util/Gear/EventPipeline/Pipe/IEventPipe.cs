using System.Collections.Generic;

namespace OregoFramework.Util.Gear
{
    public interface IEventPipe
    {
        IEvent PushEvent(IEvent inputEvent);
        
        List<IEventHandler> handlerSequence { get; }
    }
}