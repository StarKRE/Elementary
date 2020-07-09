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
    public abstract class DomainElement : Element
    {
        private IApplication application;

        private IInteractorLayer interactorLayer;

        private IClientLayer clientLayer;

        private IRepositoryLayer repositoryLayer;

        #region OnPrepare

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = Orego.GetObject<IApplication>(nameof(IApplication));
            this.clientLayer = this.application.GetClientLayer<IClientLayer>();
            this.repositoryLayer = this.application.GetRepositoryLayer<IRepositoryLayer>();
            this.interactorLayer = this.application.GetInteractorLayer<IInteractorLayer>();
        }

        #endregion

        #region Get

        protected T GetApplication<T>() where T : IApplication
        {
            return (T) this.application;
        }

        protected T GetInteractorLayer<T>() where T : IInteractorLayer
        {
            return (T) this.interactorLayer;
        }

        protected T GetInteractor<T>() where T : IInteractor
        {
            return this.interactorLayer.GetInteractor<T>();
        }

        protected IEnumerable<T> GetInteractors<T>() where T : IInteractor
        {
            return this.interactorLayer.GetInteractors<T>();
        }

        protected T GetRepositoryLayer<T>() where T : IRepositoryLayer
        {
            return (T) this.repositoryLayer;
        }

        protected T GetRepository<T>() where T : IRepository
        {
            return this.repositoryLayer.GetRepository<T>();
        }

        protected T GetClientLayer<T>() where T : IClientLayer
        {
            return (T) this.clientLayer;
        }

        protected T GetClient<T>() where T : IClient
        {
            return this.clientLayer.GetClient<T>();
        }

        #endregion
    }
}