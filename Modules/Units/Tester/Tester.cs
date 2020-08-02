#if UNITY_EDITOR
using System.Collections;
using ElementaryFramework.App;
using ElementaryFramework.Core;

namespace ElementaryFramework.Unit
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
                    var context = Elementary.GetCore<IElementContext>();
                    this._app = context.GetRoot<IApplication>();
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
                    this._databaseLayer = this.app.databaseLayer;
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
                    this._repositoryLayer = this.app.repositoryLayer;
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
                    this._interactorLayer = this.app.interactorLayer;
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
            Elementary.Initialize();
            yield return null;
        }
    }
}
#endif