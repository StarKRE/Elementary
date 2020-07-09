using System.Collections.Generic;
using OregoFramework.App;
using OregoFramework.Client;
using OregoFramework.Core;
using OregoFramework.Repo;

namespace OregoFramework.Domain
{
    /// <summary>
    ///     <para>Default implementation of domain layer.</para>
    ///     <para>This class type will added automatically by framework because
    ///     the class has attribute <see cref="OregoContext"/>.</para>
    ///     <para><see cref="Application"/> uses this domain layer by default.</para>
    /// </summary>
    [OregoContext]
    public class InteractorLayer : ElementLayer<IInteractor>, IInteractorLayer
    {
        private IApplication application;

        private IClientLayer clientLayer;

        private IRepositoryLayer repositoryLayer;

        #region OnPrepare

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = Orego.GetObject<IApplication>(nameof(IApplication));
            this.repositoryLayer = this.application.GetRepositoryLayer<IRepositoryLayer>();
            this.clientLayer = this.application.GetClientLayer<IClientLayer>();
        }

        #endregion

        public T GetInteractor<T>() where T : IInteractor
        {
            return this.GetElement<T>();
        }

        public IEnumerable<T> GetInteractors<T>() where T : IInteractor
        {
            return this.GetElements<T>();
        }

        #region Get

        protected T GetApplication<T>() where T : IApplication
        {
            return (T) this.application;
        }

        protected T GetRepositoryLayer<T>() where T : IRepositoryLayer
        {
            return (T) this.repositoryLayer;
        }

        protected T GetClientLayer<T>() where T : IClientLayer
        {
            return (T) this.clientLayer;
        }

        #endregion
    }
}