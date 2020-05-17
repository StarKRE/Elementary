using UnityEngine;

namespace OregoFramework.Util.Gear
{
    [CreateAssetMenu(
        fileName = "ChangeVelocityEventPipe",
        menuName = "Orego/Util/Event/ChangeVelocity/ChangeVelocityEventPipe"
    )]
    public class ChangeVelocityEventPipe : BaseEventPipe<ChangeVelocityEvent>
    {
        #region Const 

        private static readonly ChangeVelocityEvent DEFAULT_EVENT = new ChangeVelocityEvent(0.0f, 0.0f, 0.0f);

        #endregion

        protected override IEvent GetDefaultEvent()
        {
            return DEFAULT_EVENT;
        }
    }
}