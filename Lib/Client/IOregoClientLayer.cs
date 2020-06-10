using System.Collections.Generic;
using OregoFramework.Core;

namespace OregoFramework.Client
{
    /// <summary>
    ///     <para>Client layer interface has several clients.</para>
    /// </summary>
    public interface IOregoClientLayer : IOregoComponent
    {
        /// <summary>
        ///     <para>Gets requred client instance.</para>
        /// </summary>
        /// <typeparam name="T">Requred client type.</typeparam>
        /// <returns>Required client reference.</returns>
        T GetClient<T>() where T : IOregoClient;

        /// <summary>
        ///     <para>Gets required clients of type.</para>
        /// </summary>
        /// <typeparam name="T">Required type.</typeparam>
        /// <returns>Required client set of type.</returns>
        IEnumerable<T> GetClients<T>() where T : IOregoClient;
    }
}