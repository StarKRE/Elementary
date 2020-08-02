using System.Collections.Generic;
using ElementaryFramework.Core;

namespace ElementaryFramework.App
{
    public abstract class DomainElement : Element, IDomainElement
    {
        protected IApplication application { get; private set; }

        protected IInteractorLayer interactorLayer { get; private set; }

        protected IClientLayer clientLayer { get; private set; }

        protected IRepositoryLayer repositoryLayer { get; private set; }

        #region OnPrepare

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = this.GetRoot<IApplication>();
            this.clientLayer = this.application.clientLayer;
            this.repositoryLayer = this.application.repositoryLayer;
            this.interactorLayer = this.application.interactorLayer;
        }

        #endregion

        #region Get

        protected T GetInteractor<T>() where T : IInteractor
        {
            return this.interactorLayer.GetInteractor<T>();
        }

        protected IEnumerable<T> GetInteractors<T>() where T : IInteractor
        {
            return this.interactorLayer.GetInteractors<T>();
        }

        protected T GetRepository<T>() where T : IRepository
        {
            return this.repositoryLayer.GetRepository<T>();
        }

        protected IEnumerable<T> GetRepositories<T>() where T : IRepository
        {
            return this.repositoryLayer.GetRepositories<T>();
        }

        protected T GetClient<T>() where T : IClient
        {
            return this.clientLayer.GetClient<T>();
        }
        
        protected IEnumerable<T> GetClients<T>() where T : IClient
        {
            return this.clientLayer.GetClients<T>();
        }

        #endregion
    }
}