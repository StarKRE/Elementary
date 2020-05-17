using System;
using OregoFramework.Repo;
using UnityEngine;

namespace OregoFramework.Domain
{
    public abstract class OregoStandardObjectSourceInteractor<TObject, TRepository, TData> :
        OregoInteractor,
        IOregoObjectSourceInteractor<TObject>,
        IOregoObjectDataInitializerInteractor
        where TRepository : IOregoReadyDataRepository<TData>
    {
        #region Event

        public event Action<object> OnObjectDataInitializedEvent;

        public event Action<object, TObject> OnObjectChangedEvent;

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

        public override void OnStop()
        {
            base.OnStop();
            this.repository.OnDataReadyEvent -= this.OnRepositoryDataReady;
        }

        #endregion

        public void NotifyAboutObjectChanged(object sender, TObject obj)
        {
            this.OnObjectChangedEvent?.Invoke(sender, obj);
        }

        protected void NotifyAboutObjectDataInitialized(object sender)
        {
            this.OnObjectDataInitializedEvent?.Invoke(sender);
        }

        #region RepositoryEvents

        protected void OnRepositoryDataReady(TData data)
        {
            this.Setup(data);
            this.NotifyAboutObjectDataInitialized(this);
        }

        protected abstract void Setup(TData data);

        #endregion
    }
}