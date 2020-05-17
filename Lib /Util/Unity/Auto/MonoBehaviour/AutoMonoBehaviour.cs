using System;
using System.Collections.Generic;
using UnityEngine;

namespace OregoFramework.Util
{
    public abstract class AutoMonoBehaviour : MonoBehaviour, IDisposable
    {
        private readonly HashSet<AutoScriptableObject> scriptableObjects;

        private readonly HashSet<IDisposable> disposables;

        protected AutoMonoBehaviour()
        {
            this.scriptableObjects = new HashSet<AutoScriptableObject>();
            this.disposables = new HashSet<IDisposable>();
        }

        protected T New<T>(T asset, Action<T> initAction = null) where T : AutoScriptableObject
        {
            var scriptableObject = Instantiate(asset);
            scriptableObject.OnCreate();
            initAction?.Invoke(scriptableObject);
            this.scriptableObjects.Add(scriptableObject);
            return scriptableObject;
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
            this.scriptableObjects.ForEach(Destroy);
            this.scriptableObjects.Clear();
            this.disposables.ForEach(it => it.Dispose());
            this.disposables.Clear();
        }
    }
}