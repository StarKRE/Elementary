using UnityEngine;

namespace OregoFramework.Util
{
    public interface IReflectBehaviour2D : IBehaviour
    {
        AutoEvent<object, IReflectBehaviour2D, Collision2D> OnReflectEvent { get; }

        void OnReflect(object sender, Collision2D collision2D);
    }
}