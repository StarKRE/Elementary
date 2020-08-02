namespace ElementaryFramework.Util.Gear
{
    public interface IEventHandler
    {
        bool isEnabled { get; set; }

        IEvent HandleEvent(IEvent inputEvent);
    }
}