using System.Collections.Generic;
using ElementaryFramework.Core;

namespace ElementaryFramework.App
{
    /// <summary>
    /// <para>Base interface that contains set of different types of database.</para>
    /// </summary>
    public interface IDatabaseLayer : IElement
    {
        /// <summary>
        ///     <para>Gets required database by type.</para>
        /// </summary>
        /// <typeparam name="T">Required type.</typeparam>
        /// <returns>Required database reference.</returns>
        T GetDatabase<T>() where T : IDatabase;
        
        /// <summary>
        ///     <para>Gets required database set by type.</para>
        /// </summary>
        /// <typeparam name="T">Required type.</typeparam>
        /// <returns>Required database set.</returns>
        IEnumerable<T> GetDatabases<T>() where T : IDatabase;
    }
}