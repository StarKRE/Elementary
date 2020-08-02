using System;
using System.Collections;
using UnityEngine;

namespace ElementaryFramework.Util
{
    public sealed class Routine : IDisposable
    {
        #region Event

        public AutoEvent OnFinishedEvent { get; }

        public AutoEvent OnCanceledEvent { get; }

        #endregion

        private readonly MonoBehaviour dispatcher;

        private Coroutine routine;

        public Routine(MonoBehaviour dispatcher)
        {
            this.dispatcher = dispatcher;
            this.OnFinishedEvent = new AutoEvent();
            this.OnCanceledEvent = new AutoEvent();
        }

        #region Run

        public void Run(IEnumerator enumerator)
        {
            if (this.IsRunning())
            {
                throw new Exception("Routine is already running!");
            }

            var wrappedEnumerator = this.GetWrappedEnumerator(enumerator);
            var routine = this.dispatcher.StartCoroutine(wrappedEnumerator);
            this.routine = routine;
        }
        
        private IEnumerator GetWrappedEnumerator(IEnumerator enumerator)
        {
            yield return enumerator;
            this.routine = null;
            this.OnFinishedEvent?.Invoke();
        }

        #endregion

        public bool Cancel()
        {
            if (!this.IsRunning())
            {
                return false;
            }

            this.dispatcher.StopCoroutine(this.routine);
            this.routine = null;
            this.OnCanceledEvent?.Invoke();
            return true;
        }

        public bool IsRunning()
        {
            return this.routine != null && this.dispatcher.isActiveAndEnabled;
        }

        public void Dispose()
        {
            if (this.routine != null && this.dispatcher != null)
            {
                this.dispatcher.StopCoroutine(this.routine);
            }

            this.OnFinishedEvent.Dispose();
            this.OnCanceledEvent.Dispose();
        }
    }
}