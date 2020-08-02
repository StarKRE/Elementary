using System.Collections;
using ElementaryFramework.Core;

namespace ElementaryFramework.App
{
    public abstract class UpdateVersionRepositoryLayer : AsyncRepositoryLayer
    {
        private IUpdateVersionRepositoryManager updateVersionRepositoryManager;

        #region OnCreate

        public override void OnCreate(IElementContext context)
        {
            base.OnCreate(context);
            this.updateVersionRepositoryManager = this.LoadUpdateVersionRepositoryManager();
        }

        protected abstract IUpdateVersionRepositoryManager LoadUpdateVersionRepositoryManager();

        #endregion

        #region BeginSession

        protected sealed override IEnumerator OnAfterBeginSession()
        {
            yield return base.OnAfterBeginSession();
            yield return this.updateVersionRepositoryManager.UpdateVersionInRepositories();
            yield return this.OnAfterBeginSession(this);
        }

        protected virtual IEnumerator OnAfterBeginSession(UpdateVersionRepositoryLayer self)
        {
            yield break;
        }

        #endregion

        public T GetUpdateVersionRepositoryManager<T>() where T : IUpdateVersionRepositoryManager
        {
            return (T) this.updateVersionRepositoryManager;
        }
    }
}