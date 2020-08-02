using System.Collections.Generic;
using ElementaryFramework.Core;

namespace ElementaryFramework.App
{
    /// <summary>
    ///     <para>Client layer interface has several clients.</para>
    /// </summary>
    public interface IClientLayer : IElement
    {
        /// <summary>
        ///     <para>Gets requred client instance.</para>
        /// </summary>
        /// <typeparam name="T">Requred client type.</typeparam>
        /// <returns>Required client reference.</returns>
        T GetClient<T>() where T : IClient;

        /// <summary>
        ///     <para>Gets required clients of type.</para>
        /// </summary>
        /// <typeparam name="T">Required type.</typeparam>
        /// <returns>Required client set of type.</returns>
        IEnumerable<T> GetClients<T>() where T : IClient;
    }
}