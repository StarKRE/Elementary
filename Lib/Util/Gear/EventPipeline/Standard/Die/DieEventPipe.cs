using UnityEngine;

namespace OregoFramework.Util.Gear
{
    [CreateAssetMenu(fileName = "DieEventPipe", menuName = "Orego/Util/Event/Die/DieEventPipe")]
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