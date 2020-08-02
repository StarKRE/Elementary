using System;
using ElementaryFramework.Core;

namespace ElementaryFramework.App
{
    /// <summary>
    ///     <para>Abstraction of <see cref="IApplication"/>.</para>
    ///     <para>Implements the base abstraction layers.</para>
    /// </summary>
    public abstract class Application : Element, IApplication
    {
        public IClientLayer clientLayer { get; private set; }

        public IDatabaseLayer databaseLayer { get; private set; }

        public IRepositoryLayer repositoryLayer { get; private set; }

        public IInteractorLayer interactorLayer { get; private set; }

        #region OnCreate

        /// <summary>
        ///     <para>Creates the layers by their types.</para>
        /// </summary>
        /// <param name="context">System of framework</param>
        public override void OnCreate(IElementContext context)
        {
            base.OnCreate(context);
            this.clientLayer =
                this.CreateElement<IClientLayer>(this.GetClientLayerType());
            this.databaseLayer =
                this.CreateElement<IDatabaseLayer>(this.GetDatabaseLayerType());
            this.repositoryLayer =
                this.CreateElement<IRepositoryLayer>(this.GetRepositoryLayerType());
            this.interactorLayer =
                this.CreateElement<IInteractorLayer>(this.GetInteractorLayerType());
        }

        /// <summary>
        ///     <para>Returns a type of client layer for working with network.
        ///     The framewok system creates a instance by type.</para>
        /// </summary>
        /// <returns>Type of client layer which will be created and used in the framework system.
        /// </returns>
        protected virtual Type GetClientLayerType()
        {
            return typeof(ClientLayer);
        }

        /// <summary>
        ///     <para>Returns a type of database layer for working with local storage.
        ///     The framewok system creates a instance by type.</para>
        /// </summary>
        /// <returns>Type of database layer which will be created and used in the framework system.
        /// </returns>
        protected virtual Type GetDatabaseLayerType()
        {
            return typeof(DatabaseLayer);
        }

        /// <summary>
        ///     <para>Returns a type of repository layer for getting and setting data.
        ///     The framewok system creates a instance by type.</para>
        /// </summary>
        /// <returns>Type of repository layer which will be created and used in the framework system.
        /// </returns>
        protected virtual Type GetRepositoryLayerType()
        {
            return typeof(RepositoryLayer);
        }

        /// <summary>
        ///     <para>Returns a type of domain layer for working with business logic.
        ///     The framewok system creates a instance by type.</para>
        /// </summary>
        /// <returns>Type of repository layer which will be created and used in the framework system.
        /// </returns>
        protected virtual Type GetInteractorLayerType()
        {
            return typeof(InteractorLayer);
        }

        #endregion
    }
}