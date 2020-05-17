using System;
using System.Collections.Generic;
using UnityEngine;

namespace OregoFramework.Util
{
    public abstract class AutoScriptableObject : ScriptableObject, IDisposable
    {
        private readonly HashSet<AutoScriptableObject> scriptableObjects;

        private readonly HashSet<IDisposable> disposables;

        protected AutoScriptableObject()
        {
            this.scriptableObjects = new HashSet<AutoScriptableObject>();
            this.disposables = new HashSet<IDisposable>();
        }

        public virtual void OnCreate()
        {
            
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

        protected virtual void OnDestroy()
        {
            this.Dispose();
        }

        public virtual void Dispose()
        {
#if !UNITY_EDITOR
            this.scriptableObjects.ForEach(Destroy);
            this.scriptableObjects.Clear();
#endif
            this.disposables.ForEach(it => it.Dispose());
            this.disposables.Clear();
        }
    }
}