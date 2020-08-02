using UnityEngine;

namespace ElementaryFramework.Util
{
    public static class Collision3DUtils
    {
        public static void DisableCollision3D(this GameObject gameObject, GameObject other)
        {
            gameObject.IgnoreCollision(other, true);
        }

        public static void EnableCollision3D(this GameObject gameObject, GameObject other)
        {
            gameObject.IgnoreCollision(other, false);
        }

        private static void IgnoreCollision(this GameObject gameObject, GameObject other, bool isIgnore)
        {
            var colliders = gameObject.GetComponents<Collider>();
            var otherColliders = other.GetComponents<Collider>();
            foreach (var collider in colliders)
            {
                foreach (var otherCollider in otherColliders)
                {
                    Physics.IgnoreCollision(collider, otherCollider, isIgnore);
                }
            }
        }
    }
}