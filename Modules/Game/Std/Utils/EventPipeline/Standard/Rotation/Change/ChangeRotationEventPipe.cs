using UnityEngine;

namespace ElementaryFramework.Util.Gear
{
    public class ChangeRotationEventPipe : BaseEventPipe<ChangeRotationEvent>
    {
        #region Const 

        private static readonly ChangeRotationEvent DEFAULT_EVENT = new ChangeRotationEvent(0.0f, 0.0f, 0.0f);

        #endregion

        protected override IEvent GetDefaultEvent()
        {
            return DEFAULT_EVENT;
        }
    }
}