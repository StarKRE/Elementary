using System.Collections.Generic;
using OregoFramework.Core;

namespace OregoFramework.Client
{
    /// <summary>
    ///     <para>Base client interface.</para>
    ///     <para>Each client responsible for single request type.</para>
    /// </summary>
    /// <example>
    ///     For example you can create own impleentation of http, tcp
    ///     or ftp client deriving from this interface.  
    /// </example>
    public interface IOregoClient : IOregoComponent
    {
        /// <summary>
        ///     <para>Gets requred caller instance.</para>
        /// </summary>
        /// <typeparam name="T">Required caller type.</typeparam>
        /// <returns>Required caller reference.</returns>
        T GetCaller<T>() where T : IOregoCaller;

        /// <summary>
        ///     <para>Gets requred caller instances.</para>
        /// </summary>
        /// <typeparam name="T">Required caller type.</typeparam>
        /// <returns>Caller set with requred type.</returns>
        IEnumerable<T> GetCallers<T>() where T : IOregoCaller;
    }
}