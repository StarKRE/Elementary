using OregoFramework.Client;
using OregoFramework.Core;
using OregoFramework.Db;
using OregoFramework.Domain;
using OregoFramework.Repo;

namespace OregoFramework.App
{
    /// <summary>
    ///    <para>Base application interface.</para>
    ///    <para>Defines a contract with getting of the base abstraction layers.</para>
    /// </summary>
    public interface IOregoApplication : IOregoSingletonComponent
    {
        /// <summary>
        ///     <para>Gets the layer for working with network.</para>
        /// </summary>
        /// <typeparam name="T">Type of layer.</typeparam>
        /// <returns>Layer reference.</returns>
        T GetClientLayer<T>() where T : IOregoClientLayer;

        /// <summary>
        ///     <para>Gets the layer for working with local storage.</para>
        /// </summary>
        /// <typeparam name="T">Type of layer.</typeparam>
        /// <returns>Layer reference.</returns>
        T GetDatabaseLayer<T>() where T : IOregoDatabaseLayer;

        /// <summary>
        ///     <para>Gets the layer for getting and setting data by repository.</para>
        /// </summary>
        /// <typeparam name="T">Type of layer.</typeparam>
        /// <returns>Layer reference.</returns>
        T GetRepositoryLayer<T>() where T : IOregoRepositoryLayer;

        /// <summary>
        ///     <para>Gets the layer for working with business logic.</para>
        /// </summary>
        /// <typeparam name="T">Type of layer.</typeparam>
        /// <returns>Layer reference.</returns>
        T GetInteractorLayer<T>() where T : IOregoInteractorLayer;
    }
}