using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementaryFramework.Util
{
    public sealed class AutoEvent : AbstractAutoEvent<Action>
    {
        public void Invoke()
        {
            this.ForEach(listener => listener.Invoke());
        }
    }

    public sealed class AutoEvent<T> : AbstractAutoEvent<Action<T>>
    {
        public void Invoke(T t1)
        {
            this.ForEach(listener => listener.Invoke(t1));
        }
    }

    public sealed class AutoEvent<T1, T2> : AbstractAutoEvent<Action<T1, T2>>
    {
        public void Invoke(T1 t1, T2 t2)
        {
            this.ForEach(listener => listener.Invoke(t1, t2));
        }
    }

    public sealed class AutoEvent<T1, T2, T3> : AbstractAutoEvent<Action<T1, T2, T3>>
    {
        public void Invoke(T1 t1, T2 t2, T3 t3)
        {
            this.ForEach(listener => listener.Invoke(t1, t2, t3));
        }
    }
    
    public abstract class AbstractAutoEvent<T> : IDisposable
    {
        private bool isProcessing;

        private readonly List<T> listeners;

        private readonly Queue<Action> actionQueue;

        protected AbstractAutoEvent()
        {
            this.listeners = new List<T>();
            this.actionQueue = new Queue<Action>();
        }

        public void AddListener(T listener)
        {
            if (listener != null)
            {
                this.Try(() => this.listeners.Add(listener));
            }
        }

        public void RemoveListener(T listener)
        {
            if (listener != null)
            {
                this.Try(() => this.listeners.Remove(listener));
            }
        }

        public void ClearListeners()
        {
            this.Try(this.listeners.Clear);
        }

        private void Try(Action action)
        {
            if (this.isProcessing)
            {
                this.actionQueue.Enqueue(action);
            }
            else
            {
                action.Invoke();
            }
        }

        protected void ForEach(Action<T> action)
        {
            if (this.isProcessing)
            {
                this.actionQueue.Enqueue(() => this.ForEach(action));
                return;
            }
        
            this.isProcessing = true;
            var i = Int.ZERO;
            while (i < this.listeners.Count)
            {
                var listener = this.listeners[i++];
                action.Invoke(listener);
            }

            this.isProcessing = false;
            while (this.actionQueue.IsNotEmpty())
            {
                var deferredAction = this.actionQueue.Dequeue();
                deferredAction.Invoke();
            }
        }

        public virtual void Dispose()
        {
            this.actionQueue.Clear();
            this.listeners.Clear();
            this.isProcessing = false;
        }
    }
}