using System;
using OregoFramework.Client;
using OregoFramework.Core;
using OregoFramework.Db;
using OregoFramework.Domain;
using OregoFramework.Repo;

namespace OregoFramework.App
{
    /// <summary>
    ///     <para>Base abstact singleton implementation of <see cref="IOregoApplication"/>.</para>
    ///     <para>Implements the base abstraction layers.</para>
    ///     <para>Use Orego.GetReference﹤OregoApplication﹥ to get application reference.</para>
    /// </summary>
    public abstract class OregoApplication : OregoComponent, IOregoApplication
    {
        private IOregoClientLayer clientLayer;

        private IOregoDatabaseLayer storageLayer;

        private IOregoRepositoryLayer repositoryLayer;

        private IOregoInteractorLayer interactorLayer;

        #region OnBecameSingleton

        /// <summary>
        ///     <para>Invokes when this app instance becomes a singleton.</para>
        /// </summary>
        public virtual void OnBecameSingleton()
        {
            Orego.AddObject(nameof(IOregoApplication), this);
        }

        #endregion

        #region OnCreate

        /// <summary>
        ///     <para>Creates the base abstraction layers by their types.</para>
        /// </summary>
        public override void OnCreate()
        {
            this.clientLayer =
                this.CreateComponent<IOregoClientLayer>(this.GetClientLayerType());
            this.storageLayer =
                this.CreateComponent<IOregoDatabaseLayer>(this.GetDatabaseLayerType());
            this.repositoryLayer =
                this.CreateComponent<IOregoRepositoryLayer>(this.GetRepositoryLayerType());
            this.interactorLayer =
                this.CreateComponent<IOregoInteractorLayer>(this.GetInteractorLayerType());
        }

        /// <summary>
        ///     <para>Returns a type of client layer for working with network.
        ///     The framewok systems will get this type and will create an instance.</para>
        ///     <para>If you want to create your custom client layer then:
        ///     1.) You need to create a class that derived from <see cref="IOregoClientLayer"/>
        ///     2.) Add attribute over your custom class <see cref="OregoContext"/>
        ///     3.) Override this method.
        /// </para>
        /// </summary>
        /// <returns>Type of client layer which will be created and used in the framework system.
        /// </returns>
        protected virtual Type GetClientLayerType()
        {
            return typeof(OregoClientLayer);
        }

        /// <summary>
        ///     <para>Returns a type of database layer for working with local storage.
        ///     The framewok systems will get this type and will create an instance.</para>
        ///     <para>If you want to create your custom database layer then:
        ///     1.) You need to create a class that derived from <see cref="IOregoDatabaseLayer"/>
        ///     2.) Add attribute over your custom class <see cref="OregoContext"/>
        ///     3.) Override this method.
        /// </para>
        /// </summary>
        /// <returns>Type of database layer which will be created and used in the framework system.
        /// </returns>
        protected virtual Type GetDatabaseLayerType()
        {
            return typeof(OregoDatabaseLayer);
        }

        /// <summary>
        ///     <para>Returns a type of repository layer for getting and setting data.
        ///     The framewok systems will get this type and will create an instance.</para>
        ///     <para>If you want to create your custom repository layer then:
        ///     1.) You need to create a class that derived from <see cref="IOregoRepositoryLayer"/>
        ///     2.) Add attribute over your custom class <see cref="OregoContext"/>
        ///     3.) Override this method.
        /// </para>
        /// </summary>
        /// <returns>Type of repository layer which will be created and used in the framework system.
        /// </returns>
        protected virtual Type GetRepositoryLayerType()
        {
            return typeof(OregoRepositoryLayer);
        }

        /// <summary>
        ///     <para>Returns a type of domain layer for working with business logic.
        ///     The framewok systems will get this type and will create an instance.</para>
        ///     <para>If you want to create your custom domain layer then:
        ///     1.) You need to create a class that derived from <see cref="IOregoRepositoryLayer"/>
        ///     2.) Add attribute over your custom class <see cref="OregoContext"/>
        ///     3.) Override this method.
        /// </para>
        /// </summary>
        /// <returns>Type of repository layer which will be created and used in the framework system.
        /// </returns>
        protected virtual Type GetInteractorLayerType()
        {
            return typeof(OregoInteractorLayer);
        }

        #endregion

        public T GetClientLayer<T>() where T : IOregoClientLayer
        {
            return (T) this.clientLayer;
        }

        public T GetDatabaseLayer<T>() where T : IOregoDatabaseLayer
        {
            return (T) this.storageLayer;
        }

        public T GetRepositoryLayer<T>() where T : IOregoRepositoryLayer
        {
            return (T) this.repositoryLayer;
        }

        public T GetInteractorLayer<T>() where T : IOregoInteractorLayer
        {
            return (T) this.interactorLayer;
        }
    }
}