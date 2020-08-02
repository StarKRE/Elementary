using System;
using ElementaryFramework.App;

namespace ElementaryFramework.App
{
    public abstract class StandardItemInteractor<T, TRepository, TData> :
        Interactor,
        IItemInteractor<T>,
        IItemInitializerInteractor
        where TRepository : IReadyRepository<TData>
    {
        #region Event

        public event Action<object> OnInitializedEvent;

        public event Action<object, T> OnItemChangedEvent;

        #endregion

        protected TRepository repository { get; private set; }

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.repository = this.FetchRepository();
        }

        protected virtual TRepository FetchRepository()
        {
            return this.repository = this.GetRepository<TRepository>();
        }

        #region OnReady

        public override void OnReady()
        {
            base.OnReady();
            this.repository.OnDataReadyEvent += this.OnRepositoryDataReady;
        }

        #endregion

        #region OnStop

        public override void OnFinish()
        {
            base.OnFinish();
            this.repository.OnDataReadyEvent -= this.OnRepositoryDataReady;
        }

        #endregion

        public void NotifyAboutObjectChanged(object sender, T item)
        {
            this.OnItemChangedEvent?.Invoke(sender, item);
        }

        protected void NotifyAboutObjectDataInitialized(object sender)
        {
            this.OnInitializedEvent?.Invoke(sender);
        }

        #region RepositoryCallback

        protected void OnRepositoryDataReady(TData data)
        {
            this.Setup(data);
            this.NotifyAboutObjectDataInitialized(this);
        }

        protected abstract void Setup(TData data);

        #endregion
    }
}