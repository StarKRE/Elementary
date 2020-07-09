using System.Collections.Generic;
using OregoFramework.Util;
using UnityEngine;

namespace OregoFramework.Game
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