using System.Collections.Generic;
using ElementaryFramework.Util;
using UnityEngine;

namespace ElementaryFramework.Game
{
    public abstract class GameObjectPool : GameNode
    {
        public abstract IEnumerable<GameObject> items { get; }
        
        public abstract bool IsEmpty();

        public abstract bool IsNotEmpty();

        public abstract void Push(GameObject poolObject);

        public abstract GameObject Pop();
        
        public abstract GameObject Peek();
    }
}