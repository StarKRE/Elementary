using System.Collections.Generic;

namespace ElementaryFramework.Util.Gear
{
    public interface IEventPipe
    {
        IEvent PushEvent(IEvent inputEvent);
        
        List<IEventHandler> handlerSequence { get; }
    }
}