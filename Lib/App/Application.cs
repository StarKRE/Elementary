using System;
using OregoFramework.Client;
using OregoFramework.Core;
using OregoFramework.Db;
using OregoFramework.Domain;
using OregoFramework.Repo;

namespace OregoFramework.App
{
    /// <summary>
    ///     <para>Base abstact singleton implementation of <see cref="IApplication"/>.</para>
    ///     <para>Implements the base abstraction layers.</para>
    ///     <para>Use Orego.GetObject﹤Application﹥(nameof(Application))
    ///     to get application reference.</para>
    /// </summary>
    public abstract class Application : Element, IApplication
    {
        private IClientLayer clientLayer;

        private IDatabaseLayer storageLayer;

        private IRepositoryLayer repositoryLayer;

        private IInteractorLayer interactorLayer;

        #region OnBecameSingleton

        /// <summary>
        ///     <para>Invokes when this app instance becomes a singleton.</para>
        /// </summary>
        public virtual void OnBecameSingleton()
        {
            Orego.AddObject(nameof(IApplication), this);
        }

        #endregion

        #region OnCreate

        /// <summary>
        ///     <para>Creates the base abstraction layers by their types.</para>
        /// </summary>
        public override void OnCreate()
        {
            this.clientLayer =
                this.CreateElement<IClientLayer>(this.GetClientLayerType());
            this.storageLayer =
                this.CreateElement<IDatabaseLayer>(this.GetDatabaseLayerType());
            this.repositoryLayer =
                this.CreateElement<IRepositoryLayer>(this.GetRepositoryLayerType());
            this.interactorLayer =
                this.CreateElement<IInteractorLayer>(this.GetInteractorLayerType());
        }

        /// <summary>
        ///     <para>Returns a type of client layer for working with network.
        ///     The framewok systems will get this type and will create an instance.</para>
        ///     <para>If you want to create your custom client layer then:
        ///     1.) You need to create a class that derived from <see cref="IClientLayer"/>
        ///     2.) Add attribute over your custom class <see cref="OregoContext"/>
        ///     3.) Override this method.
        /// </para>
        /// </summary>
        /// <returns>Type of client layer which will be created and used in the framework system.
        /// </returns>
        protected virtual Type GetClientLayerType()
        {
            return typeof(ClientLayer);
        }

        /// <summary>
        ///     <para>Returns a type of database layer for working with local storage.
        ///     The framewok systems will get this type and will create an instance.</para>
        ///     <para>If you want to create your custom database layer then:
        ///     1.) You need to create a class that derived from <see cref="IDatabaseLayer"/>
        ///     2.) Add attribute over your custom class <see cref="OregoContext"/>
        ///     3.) Override this method.
        /// </para>
        /// </summary>
        /// <returns>Type of database layer which will be created and used in the framework system.
        /// </returns>
        protected virtual Type GetDatabaseLayerType()
        {
            return typeof(DatabaseLayer);
        }

        /// <summary>
        ///     <para>Returns a type of repository layer for getting and setting data.
        ///     The framewok systems will get this type and will create an instance.</para>
        ///     <para>If you want to create your custom repository layer then:
        ///     1.) You need to create a class that derived from <see cref="IRepositoryLayer"/>
        ///     2.) Add attribute over your custom class <see cref="OregoContext"/>
        ///     3.) Override this method.
        /// </para>
        /// </summary>
        /// <returns>Type of repository layer which will be created and used in the framework system.
        /// </returns>
        protected virtual Type GetRepositoryLayerType()
        {
            return typeof(RepositoryLayer);
        }

        /// <summary>
        ///     <para>Returns a type of domain layer for working with business logic.
        ///     The framewok systems will get this type and will create an instance.</para>
        ///     <para>If you want to create your custom domain layer then:
        ///     1.) You need to create a class that derived from <see cref="IRepositoryLayer"/>
        ///     2.) Add attribute over your custom class <see cref="OregoContext"/>
        ///     3.) Override this method.
        /// </para>
        /// </summary>
        /// <returns>Type of repository layer which will be created and used in the framework system.
        /// </returns>
        protected virtual Type GetInteractorLayerType()
        {
            return typeof(InteractorLayer);
        }

        #endregion

        public T GetClientLayer<T>() where T : IClientLayer
        {
            return (T) this.clientLayer;
        }

        public T GetDatabaseLayer<T>() where T : IDatabaseLayer
        {
            return (T) this.storageLayer;
        }

        public T GetRepositoryLayer<T>() where T : IRepositoryLayer
        {
            return (T) this.repositoryLayer;
        }

        public T GetInteractorLayer<T>() where T : IInteractorLayer
        {
            return (T) this.interactorLayer;
        }
    }
}