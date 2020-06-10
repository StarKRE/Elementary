using UnityEngine;

namespace OregoFramework.Util.Gear
{
    [CreateAssetMenu(
        fileName = "MakeUndamagableEventHandler",
        menuName = "Orego/Util/Event/TakeDamage/New MakeUndamagableEventHandler"
    )]
    public sealed class MakeUndamagableEventHandler : TakeDamageEventHandler
    {
        protected override TakeDamageEvent OnHandleEvent(TakeDamageEvent inputEvent)
        {
            return null;
        }
    }
}