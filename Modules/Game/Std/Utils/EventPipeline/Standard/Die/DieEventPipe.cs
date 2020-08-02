using UnityEngine;

namespace ElementaryFramework.Util.Gear
{
    public class DieEventPipe : BaseEventPipe<DieEvent>
    {
        #region Const 

        private static readonly DieEvent DEFAULT_EVENT = null;

        #endregion

        protected override IEvent GetDefaultEvent()
        {
            return DEFAULT_EVENT;
        }
    }
}