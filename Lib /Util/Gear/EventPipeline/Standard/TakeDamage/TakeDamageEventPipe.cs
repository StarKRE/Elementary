using UnityEngine;

namespace OregoFramework.Util.Gear
{
    [CreateAssetMenu(
        fileName = "TakeDamageEventPipe",
        menuName = "Orego/Util/Event/TakeDamage/TakeDamageEventPipe"
    )]
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