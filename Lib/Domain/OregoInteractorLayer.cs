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
    ///     <para><see cref="OregoApplication"/> uses this domain layer by default.</para>
    /// </summary>
    [OregoContext]
    public class OregoInteractorLayer : OregoComponentLayer<IOregoInteractor>, IOregoInteractorLayer
    {
        private IOregoApplication application;

        private IOregoClientLayer clientLayer;

        private IOregoRepositoryLayer repositoryLayer;

        #region OnPrepare

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = Orego.GetObject<IOregoApplication>(nameof(IOregoApplication));
            this.repositoryLayer = this.application.GetRepositoryLayer<IOregoRepositoryLayer>();
            this.clientLayer = this.application.GetClientLayer<IOregoClientLayer>();
        }

        #endregion

        public T GetInteractor<T>() where T : IOregoInteractor
        {
            return (T) this[typeof(T)];
        }

        public IEnumerable<T> GetInteractors<T>() where T : IOregoInteractor
        {
            return this.GetComponents<T>();
        }

        #region Get

        protected T GetApplication<T>() where T : IOregoApplication
        {
            return (T) this.application;
        }

        protected T GetRepositoryLayer<T>() where T : IOregoRepositoryLayer
        {
            return (T) this.repositoryLayer;
        }

        protected T GetClientLayer<T>() where T : IOregoClientLayer
        {
            return (T) this.clientLayer;
        }

        #endregion
    }
}