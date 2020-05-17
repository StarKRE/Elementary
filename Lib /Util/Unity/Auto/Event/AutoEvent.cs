using System;
using System.Linq;

namespace OregoFramework.Util
{
    public class AutoEvent : AutoAbstractEvent<Action>
    {
        public virtual void Invoke()
        {
            var i = Int.ZERO;
            while (i < this.listeners.Count)
            {
                var listener = this.listeners[i++];
                listener.Invoke();
            }
        }
    }

    public class AutoEvent<T> : AutoAbstractEvent<Action<T>>
    {
        public virtual void Invoke(T value)
        {
            var i = Int.ZERO;
            while (i < this.listeners.Count)
            {
                var listener = this.listeners[i++];
                listener.Invoke(value);
            }
        }
    }

    public class AutoEvent<T1, T2> : AutoAbstractEvent<Action<T1, T2>>
    {
        public virtual void Invoke(T1 t1, T2 t2)
        {
            var i = Int.ZERO;
            while (i < this.listeners.Count)
            {
                var listener = this.listeners[i++];
                listener.Invoke(t1, t2);
            }
        }
    }

    public class AutoEvent<T1, T2, T3> : AutoAbstractEvent<Action<T1, T2, T3>>
    {
        public virtual void Invoke(T1 t1, T2 t2, T3 t3)
        {
            var i = Int.ZERO;
            while (i < this.listeners.Count)
            {
                var listener = this.listeners[i++];
                listener.Invoke(t1, t2, t3);
            }
        }
    }
}