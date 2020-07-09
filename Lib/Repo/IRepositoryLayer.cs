using System.Collections.Generic;
using OregoFramework.Core;

namespace OregoFramework.Repo
{
    /// <summary>
    ///     <para>Base interface of repository layer.</para>
    /// </summary>
    public interface IRepositoryLayer : IElement
    {
        /// <summary>
        ///     <para>Gets required repository by type.</para>
        /// </summary>
        /// <typeparam name="T">Required type.</typeparam>
        /// <returns>Instance of required type.</returns>
        T GetRepository<T>() where T : IRepository;

        /// <summary>
        ///     <para>Gets required repositories by type.</para>
        /// </summary>
        /// <typeparam name="T">Required type.</typeparam>
        /// <returns>Repositories of required type.</returns>
        IEnumerable<T> GetRepositories<T>() where T : IRepository;
    }
}