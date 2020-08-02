namespace ElementaryFramework.Util.Gear
{
    public class TakeDamageEventPipe : BaseEventPipe<TakeDamageEvent>
    {
        #region Const

        private static readonly TakeDamageEvent DEFAULT_EVENT = new TakeDamageEvent(0);

        #endregion

        protected override IEvent GetDefaultEvent()
        {
            return DEFAULT_EVENT;
        }
    }
}