using System;
using System.Collections.Generic;
using UnityEngine;

namespace OregoFramework.Util
{
    public abstract class AutoMonoBehaviour : MonoBehaviour, IDisposable
    {
        private readonly HashSet<IDisposable> disposables;

        protected AutoMonoBehaviour()
        {
            this.disposables = new HashSet<IDisposable>();
        }

        protected T New<T>(Action<T> initAction = null) where T : IDisposable, new()
        {
            var disposable = new T();
            initAction?.Invoke(disposable);
            this.disposables.Add(disposable);
            return disposable;
        }
        
        protected Routine NewRoutine()
        {
            var routine = new Routine(this);
            this.disposables.Add(routine);
            return routine;
        }

        protected virtual void OnDestroy()
        {
            this.Dispose();
        }

        public virtual void Dispose()
        {
            this.disposables.ForEach(it => it.Dispose());
            this.disposables.Clear();
        }
    }
}