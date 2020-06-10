using System;
using System.Collections.Generic;

namespace OregoFramework.Util
{
    public abstract class AutoAbstractEvent<A> : IDisposable
    {
        protected readonly List<A> listeners;

        protected AutoAbstractEvent()
        {
            this.listeners = new List<A>();
        }

        public virtual void AddListener(A action)
        {
            if (action != null)
            {
                this.listeners.Add(action);
            }
        }

        public virtual void RemoveListener(A action)
        {
            if (action != null)
            {
                this.listeners.Remove(action);
            }
        }

        public virtual void RemoveAllListeners()
        {
            this.listeners.Clear();
        }

        public virtual void Dispose()
        {
            this.RemoveAllListeners();
        }
    }
}