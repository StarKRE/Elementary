using System.Collections.Generic;
using UnityEngine;

namespace ElementaryFramework.Game
{
    public class GameComponentQueuePool<T> : GameObjectQueuePool where T : Component
    {
        protected readonly HashSet<T> gameComponents;

        protected readonly Dictionary<T, GameObject> componentVsPoolableMap;

        protected readonly Dictionary<GameObject, T> poolableVsComponentMap;

        public GameComponentQueuePool()
        {
            this.gameComponents = new HashSet<T>();
            this.componentVsPoolableMap = new Dictionary<T, GameObject>();
            this.poolableVsComponentMap = new Dictionary<GameObject, T>();
        }

        protected override void InitPooledGameObject(GameObject pooledGameObject)
        {
            base.InitPooledGameObject(pooledGameObject);
            var item = pooledGameObject.GetComponent<T>();
            this.gameComponents.Add(item);
            this.poolableVsComponentMap.Add(pooledGameObject, item);
            this.componentVsPoolableMap.Add(item, pooledGameObject);
        }

        public IEnumerable<T> GetAsComponents()
        {
            return this.gameComponents;
        }
        
        public T PeekAsComponent()
        {
            var poolable = this.Peek();
            return this.poolableVsComponentMap[poolable];
        }

        public T PopAsComponent()
        {
            var poolable = this.Pop();
            return this.poolableVsComponentMap[poolable];
        }

        public void PushAsComponent(T item)
        {
            var poolable = this.componentVsPoolableMap[item];
            this.Push(poolable);
        }
    }
}