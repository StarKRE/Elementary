using OregoFramework.App;
using OregoFramework.Client;
using OregoFramework.Core;
using OregoFramework.Db;

namespace OregoFramework.Repo
{
    /// <summary>
    ///     <para>Controller for work with data.</para>
    /// </summary>
    public abstract class OregoRepositoryComponent : OregoComponent
    {
        private IOregoApplication application;

        private IOregoRepositoryLayer repositoryLayer;

        private IOregoDatabaseLayer databaseLayer;

        private IOregoClientLayer clientLayer;

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = Orego.GetObject<IOregoApplication>(nameof(IOregoApplication));
            this.repositoryLayer = this.application.GetRepositoryLayer<IOregoRepositoryLayer>();
            this.databaseLayer = this.application.GetDatabaseLayer<IOregoDatabaseLayer>();
            this.clientLayer = this.application.GetClientLayer<IOregoClientLayer>();
        }

        protected T GetApplication<T>() where T : IOregoApplication
        {
            return (T) this.application;
        }

        protected T GetRepositoryLayer<T>() where T : IOregoRepositoryLayer
        {
            return (T) this.repositoryLayer;
        }

        protected T GetDatabaseLayer<T>() where T : IOregoDatabase
        {
            return (T) this.databaseLayer;
        }

        protected T GetDatabase<T>() where T : IOregoDatabase
        {
            return this.databaseLayer.GetDatabase<T>();
        }

        protected T GetClientLayer<T>() where T : IOregoClientLayer
        {
            return (T) this.clientLayer;
        }

        protected T GetClient<T>() where T : IOregoClient
        {
            return this.clientLayer.GetClient<T>();
        }
    }
}