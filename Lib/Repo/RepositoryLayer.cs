using System.Collections.Generic;
using OregoFramework.App;
using OregoFramework.Client;
using OregoFramework.Core;
using OregoFramework.Db;

namespace OregoFramework.Repo
{
    /// <summary>
    ///     <para>Default implementation of repository layer.</para>
    ///     <para>This class type will added automatically by framework because
    ///     the class has attribute <see cref="OregoContext"/>.</para>
    ///     <para><see cref="Application"/> uses this repository layer by default.</para>
    /// </summary>
    [OregoContext]
    public class RepositoryLayer : ElementLayer<IRepository>, IRepositoryLayer
    {
        public bool isActiveSession { get; protected set; }

        private IApplication application;

        private IDatabaseLayer databaseLayer;

        private IClientLayer clientLayer;

        #region OnPrepare

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = Orego.GetObject<IApplication>(nameof(IApplication));
            this.databaseLayer = this.application.GetDatabaseLayer<IDatabaseLayer>();
            this.clientLayer = this.application.GetClientLayer<IClientLayer>();
        }

        #endregion

        public T GetRepository<T>() where T : IRepository
        {
            return this.GetElement<T>();
        }

        public IEnumerable<T> GetRepositories<T>() where T : IRepository
        {
            return this.GetElements<T>();
        }

        protected T GetApplication<T>() where T : Application
        {
            return (T) this.application;
        }

        protected T GetDatabaseLayer<T>() where T : DatabaseLayer
        {
            return (T) this.databaseLayer;
        }

        protected T GetClientLayer<T>() where T : ClientLayer
        {
            return (T) this.clientLayer;
        }
    }
}