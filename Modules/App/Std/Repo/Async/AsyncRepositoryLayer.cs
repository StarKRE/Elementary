using System.Collections;
using ElementaryFramework.Util;

namespace ElementaryFramework.App
{
    public abstract class AsyncRepositoryLayer : RepositoryLayer
    {
        #region Event

        public AsyncEvent OnBeginSessionEvent { get; }

        public AsyncEvent OnEndSessionEvent { get; }

        #endregion

        protected AsyncRepositoryLayer()
        {
            this.OnBeginSessionEvent = new AsyncEvent();
            this.OnEndSessionEvent = new AsyncEvent();
        }

        public override void OnDispose()
        {
            base.OnDispose();
            this.OnBeginSessionEvent.Dispose();
            this.OnEndSessionEvent.Dispose();
        }

        public IEnumerator BeginSession()
        {
            yield return this.OnBeforeBeginSession();
            var repositories = this.GetRepositories<IAsyncRepository>();
            foreach (var repository in repositories)
            {
                yield return repository.OnBeginSession();
            }

            this.isActiveSession = true;
            yield return this.OnAfterBeginSession();
            yield return this.OnBeginSessionEvent?.Invoke();
        }

        protected virtual IEnumerator OnBeforeBeginSession()
        {
            yield break;
        }

        protected virtual IEnumerator OnAfterBeginSession()
        {
            yield break;
        }

        public IEnumerator EndSession()
        {
            yield return this.OnBeforeEndSession();
            this.isActiveSession = false;
            yield return this.OnEndSessionEvent?.Invoke();
            var repositories = this.GetRepositories<IAsyncRepository>();
            foreach (var repository in repositories)
            {
                yield return repository.OnEndSession();
            }

            yield return this.OnAfterEndSession();
        }

        protected virtual IEnumerator OnBeforeEndSession()
        {
            yield break;
        }

        protected virtual IEnumerator OnAfterEndSession()
        {
            yield break;
        }
    }
}