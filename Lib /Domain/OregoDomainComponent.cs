using System.Collections.Generic;
using OregoFramework.App;
using OregoFramework.Client;
using OregoFramework.Core;
using OregoFramework.Repo;

namespace OregoFramework.Domain
{
    /// <summary>
    ///     <para>Controller for work with business logic.</para>
    /// </summary>
    public abstract class OregoDomainComponent : OregoComponent
    {
        private IOregoApplication application;

        private IOregoInteractorLayer interactorLayer;

        private IOregoClientLayer clientLayer;

        private IOregoRepositoryLayer repositoryLayer;

        #region OnPrepare

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = Orego.GetObject<IOregoApplication>(nameof(IOregoApplication));
            this.clientLayer = this.application.GetClientLayer<IOregoClientLayer>();
            this.repositoryLayer = this.application.GetRepositoryLayer<IOregoRepositoryLayer>();
            this.interactorLayer = this.application.GetInteractorLayer<IOregoInteractorLayer>();
        }

        #endregion

        #region Get

        protected T GetApplication<T>() where T : IOregoApplication
        {
            return (T) this.application;
        }

        protected T GetInteractorLayer<T>() where T : IOregoInteractorLayer
        {
            return (T) this.interactorLayer;
        }

        protected T GetInteractor<T>() where T : IOregoInteractor
        {
            return this.interactorLayer.GetInteractor<T>();
        }

        protected IEnumerable<T> GetInteractors<T>() where T : IOregoInteractor
        {
            return this.interactorLayer.GetInteractors<T>();
        }

        protected T GetRepositoryLayer<T>() where T : IOregoRepositoryLayer
        {
            return (T) this.repositoryLayer;
        }

        protected T GetRepository<T>() where T : IOregoRepository
        {
            return this.repositoryLayer.GetRepository<T>();
        }

        protected T GetClientLayer<T>() where T : IOregoClientLayer
        {
            return (T) this.clientLayer;
        }

        protected T GetClient<T>() where T : IOregoClient
        {
            return this.clientLayer.GetClient<T>();
        }

        #endregion
    }
}