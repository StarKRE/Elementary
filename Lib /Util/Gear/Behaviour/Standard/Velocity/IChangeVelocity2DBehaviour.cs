using UnityEngine;

namespace OregoFramework.Util
{
    public interface IChangeVelocity2DBehaviour : IBehaviour
    {
        AutoEvent<object, IChangeVelocity2DBehaviour, Vector2> OnVelocity2ChangedEvent { get; }

        void OnChangeVelocity(object sender, Vector2 velocity);
    }
}