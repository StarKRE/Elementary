using System.Collections;

namespace OregoFramework.Repo
{
    public abstract class OregoUpdateVersionRepositoryLayer : OregoAsyncRepositoryLayer
    {
        private IOregoUpdateVersionRepositoryManager updateVersionRepositoryManager;

        #region OnCreate

        public override void OnCreate()
        {
            base.OnCreate();
            this.updateVersionRepositoryManager = this.LoadUpdateVersionRepositoryManager();
        }

        protected abstract IOregoUpdateVersionRepositoryManager LoadUpdateVersionRepositoryManager();

        #endregion

        #region BeginSession

        protected sealed override IEnumerator OnAfterBeginSession()
        {
            yield return base.OnAfterBeginSession();
            yield return this.updateVersionRepositoryManager.UpdateVersionInRepositories();
            yield return this.OnAfterBeginSession(this);
        }

        protected virtual IEnumerator OnAfterBeginSession(OregoUpdateVersionRepositoryLayer self)
        {
            yield break;
        }

        #endregion

        public T GetUpdateVersionRepositoryManager<T>() where T : IOregoUpdateVersionRepositoryManager
        {
            return (T) this.updateVersionRepositoryManager;
        }
    }
}