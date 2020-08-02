using ElementaryFramework.Util;
using UnityEngine;

namespace ElementaryFramework.Game
{
    public abstract class GamePrefabQueuePool<T> : GameComponentQueuePool<T>
        where T : Component
    {
        [SerializeField]
        protected GameObject m_prefab;

        [SerializeField]
        protected int m_objectCount;

        [SerializeField]
        protected Transform m_containerTransform;

        protected virtual void CreatePooledGameObjects()
        {
            for (var i = Int.ZERO; i < this.m_objectCount; i++)
            {
                var pooledObject = Instantiate(this.m_prefab, this.m_containerTransform);
                this.InitPooledGameObject(pooledObject);
            }
        }
    }
}