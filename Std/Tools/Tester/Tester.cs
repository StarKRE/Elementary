#if UNITY_EDITOR
using System.Collections;
using OregoFramework.App;
using OregoFramework.Core;
using OregoFramework.Db;
using OregoFramework.Domain;
using OregoFramework.Repo;

namespace OregoFramework.Tests
{
    public abstract class Tester
    {
        private IApplication _app;

        protected IApplication app
        {
            get
            {
                if (this._app == null)
                {
                    this._app = Orego.GetObject<IApplication>(nameof(IApplication));
                }

                return this._app;
            }
        }

        private IDatabaseLayer _databaseLayer;

        protected IDatabaseLayer databaseLayer
        {
            get
            {
                if (this._databaseLayer == null)
                {
                    this._databaseLayer = this.app.GetDatabaseLayer<IDatabaseLayer>();
                }

                return this._databaseLayer;
            }
        }

        private IRepositoryLayer _repositoryLayer;

        protected IRepositoryLayer repositoryLayer
        {
            get
            {
                if (this._repositoryLayer == null)
                {
                    this._repositoryLayer = this.app.GetRepositoryLayer<IRepositoryLayer>();
                }

                return this._repositoryLayer;
            }
        }

        private IInteractorLayer _interactorLayer;

        protected IInteractorLayer interactorLayer
        {
            get
            {
                if (this._interactorLayer == null)
                {
                    this._interactorLayer = this.app.GetInteractorLayer<IInteractorLayer>();
                }

                return this._interactorLayer;
            }
        }

        protected T GetDatabase<T>() where T : IDatabase
        {
            return this.databaseLayer.GetDatabase<T>();
        }

        protected T GetRepository<T>() where T : IRepository
        {
            return this.repositoryLayer.GetRepository<T>();
        }

        protected T GetInteractor<T>() where T : IInteractor
        {
            return this.interactorLayer.GetInteractor<T>();
        }

        protected virtual IEnumerator LaunchApp()
        {
            Orego.Start();
            yield return null;
        }
    }
}
#endif