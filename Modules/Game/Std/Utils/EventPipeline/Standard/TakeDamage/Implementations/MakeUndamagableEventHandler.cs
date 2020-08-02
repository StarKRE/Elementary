using UnityEngine;

namespace ElementaryFramework.Util.Gear
{
    public sealed class MakeUndamagableEventHandler : TakeDamageEventHandler
    {
        protected override TakeDamageEvent OnHandleEvent(TakeDamageEvent inputEvent)
        {
            return null;
        }
    }
}