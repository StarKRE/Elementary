using System.Collections;
using System.Collections.Generic;
using OregoFramework.Core;

namespace OregoFramework.Repo
{
    public abstract class OregoAsyncRepositoryLayer : OregoRepositoryLayer
    {
        private readonly HashSet<IOregoOnBeginSessionAsyncListener> onBeginSessionListeners;

        private readonly HashSet<IOregoOnEndSessionAsyncListener> onEndSessionAsyncListeners;

        protected OregoAsyncRepositoryLayer()
        {
            this.onBeginSessionListeners = new HashSet<IOregoOnBeginSessionAsyncListener>();
            this.onEndSessionAsyncListeners = new HashSet<IOregoOnEndSessionAsyncListener>();
        }

        #region Begin

        public IEnumerator BeginSession()
        {
            yield return this.OnBeforeBeginSession();
            yield return this.BeginSessionInRepositories();
            this.isActiveSession = true;
            yield return this.OnAfterBeginSession();
            yield return this.BroadcastOnBeginSessionEvent();
        }

        protected virtual IEnumerator OnBeforeBeginSession()
        {
            yield break;
        }

        protected IEnumerator BeginSessionInRepositories()
        {
            var repositories = this.GetComponents<IOregoAsyncRepository>();
            foreach (var repository in repositories)
            {
                yield return repository.OnBeginSession();
            }
        }

        protected virtual IEnumerator OnAfterBeginSession()
        {
            yield break;
        }

        private IEnumerator BroadcastOnBeginSessionEvent()
        {
            foreach (var asyncListener in this.onBeginSessionListeners)
            {
                yield return asyncListener.OnBeginSessionAsync();
            }
        }

        public void AddOnBeginSessionListener(IOregoOnBeginSessionAsyncListener listener)
        {
            this.onBeginSessionListeners.Add(listener);
        }

        public void RemoveOnBeginSessionListener(IOregoOnBeginSessionAsyncListener listener)
        {
            this.onBeginSessionListeners.Remove(listener);
        }

        #endregion

        #region End

        public IEnumerator EndSession()
        {
            yield return this.OnBeforeEndSession();
            this.isActiveSession = false;
            yield return this.BroadcastOnEndSessionEvent();
            yield return this.EndSessionInRepositories();
            yield return this.OnAfterEndSession();
        }

        protected virtual IEnumerator OnBeforeEndSession()
        {
            yield break;
        }

        private IEnumerator BroadcastOnEndSessionEvent()
        {
            foreach (var asyncListener in this.onEndSessionAsyncListeners)
            {
                yield return asyncListener.OnEndSessionAsync();
            }
        }

        protected virtual IEnumerator EndSessionInRepositories()
        {
            var repositories = this.GetComponents<IOregoAsyncRepository>();
            foreach (var repository in repositories)
            {
                yield return repository.OnEndSession();
            }
        }

        protected virtual IEnumerator OnAfterEndSession()
        {
            yield break;
        }

        public void AddOnEndSessionListener(IOregoOnEndSessionAsyncListener listener)
        {
            this.onEndSessionAsyncListeners.Add(listener);
        }

        public void RemoveOnEndSessionListener(IOregoOnEndSessionAsyncListener listener)
        {
            this.onEndSessionAsyncListeners.Remove(listener);
        }

        #endregion
    }
}