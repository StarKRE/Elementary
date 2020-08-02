using System.Collections.Generic;
using ElementaryFramework.Core;

namespace ElementaryFramework.App
{
    /// <summary>
    ///     <para>Default implementation of domain layer.</para>
    ///     <para>This class type will added automatically by framework because
    ///     the class has attribute <see cref="Using"/>.</para>
    ///     <para><see cref="Application"/> uses this domain layer by default.</para>
    /// </summary>
    [Using]
    public class InteractorLayer : ElementLayer<IInteractor>, IInteractorLayer
    {
        protected IApplication application { get; private set; }

        protected IClientLayer clientLayer { get; private set; }

        protected IRepositoryLayer repositoryLayer { get; private set; }

        #region OnPrepare

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = this.GetRoot<IApplication>();
            this.clientLayer = this.application.clientLayer;
            this.repositoryLayer = this.application.repositoryLayer;
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
    }
}