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
    ///     <para><see cref="OregoApplication"/> uses this repository layer by default.</para>
    /// </summary>
    [OregoContext]
    public class OregoRepositoryLayer : OregoComponentLayer<IOregoRepository>, IOregoRepositoryLayer
    {
        public bool isActiveSession { get; protected set; }

        private IOregoApplication application;

        private IOregoDatabaseLayer databaseLayer;

        private IOregoClientLayer clientLayer;

        #region OnPrepare

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = Orego.GetObject<IOregoApplication>(nameof(IOregoApplication));
            this.databaseLayer = this.application.GetDatabaseLayer<IOregoDatabaseLayer>();
            this.clientLayer = this.application.GetClientLayer<IOregoClientLayer>();
        }

        #endregion

        public T GetRepository<T>() where T : IOregoRepository
        {
            return (T) this[typeof(T)];
        }

        public IEnumerable<T> GetRepositories<T>() where T : IOregoRepository
        {
            return this.GetComponents<T>();
        }

        protected T GetApplication<T>() where T : OregoApplication
        {
            return (T) this.application;
        }

        protected T GetDatabaseLayer<T>() where T : OregoDatabaseLayer
        {
            return (T) this.databaseLayer;
        }

        protected T GetClientLayer<T>() where T : OregoClientLayer
        {
            return (T) this.clientLayer;
        }
    }
}