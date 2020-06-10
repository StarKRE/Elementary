using System.Collections.Generic;
using OregoFramework.Core;

namespace OregoFramework.Db
{
    /// <summary>
    ///     <para>Base interface that contains data access objects.</para>
    /// </summary>
    public interface IOregoDatabase : IOregoComponent
    {
        /// <summary>
        ///     <para>Gets a required data access object of type.</para>
        /// </summary>
        /// <typeparam name="T">Required type.</typeparam>
        /// <returns>Instance of requred data access object.</returns>
        T GetDao<T>() where T : IOregoDao;

        /// <summary>
        /// <para></para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> GetDaoSet<T>() where T : IOregoDao;
    }
}