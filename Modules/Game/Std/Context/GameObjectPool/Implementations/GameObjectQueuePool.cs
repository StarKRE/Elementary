using System.Collections.Generic;
using System.Linq;
using ElementaryFramework.Util;
using UnityEngine;

namespace ElementaryFramework.Game
{
    public abstract class GameObjectQueuePool : GameObjectPool
    {
        protected readonly HashSet<GameObject> gameObjects;
        
        protected readonly Queue<GameObject> availableGameObjects;

        protected GameObjectQueuePool()
        {
            this.gameObjects = new HashSet<GameObject>();
            this.availableGameObjects = new Queue<GameObject>();
        }

        public override IEnumerable<GameObject> items
        {
            get { return this.gameObjects; }
        }

        #region InitGameObjects

        protected virtual void InitPooledGameObject(GameObject pooledGameObject)
        {
            this.gameObjects.Add(pooledGameObject);
            this.availableGameObjects.Enqueue(pooledGameObject);
        }
        
        #endregion

        public override void Push(GameObject poolObject)
        {
            this.availableGameObjects.Enqueue(poolObject);
        }

        public override GameObject Pop()
        {
            return this.availableGameObjects.Dequeue();
        }

        public override GameObject Peek()
        {
            return this.availableGameObjects.Peek();
        }
        
        public override bool IsEmpty()
        {
            return this.availableGameObjects.IsEmpty();
        }

        public override bool IsNotEmpty()
        {
            return this.availableGameObjects.IsNotEmpty();
        }
    }
}