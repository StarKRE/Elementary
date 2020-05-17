using System;
using System.Collections;
using UnityEngine;

namespace OregoFramework.Util
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

        #region Start

        public void Start(IEnumerator enumerator)
        {
            if (this.IsWorking())
            {
                return;
            }

            if (!this.dispatcher.isActiveAndEnabled)
            {
                return;
            }

            var wrappedEnumerator = this.GetWrappedEnumerator(enumerator);
            var routine = this.dispatcher.StartCoroutine(wrappedEnumerator);
            this.routine = routine;
        }

        #endregion

        private IEnumerator GetWrappedEnumerator(IEnumerator enumerator)
        {
            yield return enumerator;
            this.routine = null;
            this.OnFinishedEvent?.Invoke();
        }

        #region Cancel

        public void Cancel()
        {
            if (!this.IsWorking())
            {
                return;
            }

            this.dispatcher.StopCoroutine(this.routine);
            this.routine = null;
            this.OnCanceledEvent?.Invoke();
        }

        #endregion

        #region IsWorking

        public bool IsWorking()
        {
            return this.routine != null;
        }

        #endregion

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