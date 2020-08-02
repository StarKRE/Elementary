using ElementaryFramework.Core;

namespace ElementaryFramework.App
{
    /// <summary>
    ///     <para>Controller for work with data.</para>
    /// </summary>
    public abstract class RepoElement : Element, IRepoElement
    {
        protected IApplication application { get; private set; }

        protected IRepositoryLayer repositoryLayer { get; private set; }

        protected IDatabaseLayer databaseLayer { get; private set; }

        protected IClientLayer clientLayer { get; private set; }

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = this.GetRoot<IApplication>();
            this.repositoryLayer = this.application.repositoryLayer;
            this.databaseLayer = this.application.databaseLayer;
            this.clientLayer = this.application.clientLayer;
        }

        protected T GetDatabase<T>() where T : IDatabase
        {
            return this.databaseLayer.GetDatabase<T>();
        }

        protected T GetClient<T>() where T : IClient
        {
            return this.clientLayer.GetClient<T>();
        }
    }
}