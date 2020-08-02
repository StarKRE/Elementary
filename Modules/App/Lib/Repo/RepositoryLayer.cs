using System.Collections.Generic;
using ElementaryFramework.Core;

namespace ElementaryFramework.App
{
    /// <summary>
    ///     <para>Default implementation of repository layer.</para>
    ///     <para>This class type will added automatically by framework because
    ///     the class has attribute <see cref="Using"/>.</para>
    ///     <para><see cref="Application"/> uses this repository layer by default.</para>
    /// </summary>
    [Using]
    public class RepositoryLayer : ElementLayer<IRepository>, IRepositoryLayer
    {
        public bool isActiveSession { get; protected set; }

        protected IApplication application { get; private set; }

        protected IDatabaseLayer databaseLayer { get; private set; }

        protected IClientLayer clientLayer { get; private set; }

        #region OnPrepare

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = this.GetRoot<IApplication>();
            this.databaseLayer = this.application.databaseLayer;
            this.clientLayer = this.application.clientLayer;
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
    }
}