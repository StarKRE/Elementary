namespace OregoFramework.Util.Gear
{
    public interface IEventHandler
    {
        bool isEnabled { get; set; }

        IEvent HandleEvent(IEvent inputEvent);
    }
}