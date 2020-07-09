using OregoFramework.App;
using OregoFramework.Client;
using OregoFramework.Core;
using OregoFramework.Db;

namespace OregoFramework.Repo
{
    /// <summary>
    ///     <para>Controller for work with data.</para>
    /// </summary>
    public abstract class RepoElement : Element
    {
        private IApplication application;

        private IRepositoryLayer repositoryLayer;

        private IDatabaseLayer databaseLayer;

        private IClientLayer clientLayer;

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = Orego.GetObject<IApplication>(nameof(IApplication));
            this.repositoryLayer = this.application.GetRepositoryLayer<IRepositoryLayer>();
            this.databaseLayer = this.application.GetDatabaseLayer<IDatabaseLayer>();
            this.clientLayer = this.application.GetClientLayer<IClientLayer>();
        }

        protected T GetApplication<T>() where T : IApplication
        {
            return (T) this.application;
        }

        protected T GetRepositoryLayer<T>() where T : IRepositoryLayer
        {
            return (T) this.repositoryLayer;
        }

        protected T GetDatabaseLayer<T>() where T : IDatabase
        {
            return (T) this.databaseLayer;
        }

        protected T GetDatabase<T>() where T : IDatabase
        {
            return this.databaseLayer.GetDatabase<T>();
        }

        protected T GetClientLayer<T>() where T : IClientLayer
        {
            return (T) this.clientLayer;
        }

        protected T GetClient<T>() where T : IClient
        {
            return this.clientLayer.GetClient<T>();
        }
    }
}