using System.Collections.Generic;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>The modular config delegates deploying of the framework system to the his
    ///     modules.</para>
    /// </summary>
    public interface IOregoModularConfig
    {
        /// <summary>
        ///     <para>Gets all modules of required type.</para>
        /// </summary>
        /// <typeparam name="T">Required type.</typeparam>
        /// <returns>A set of required modules.</returns>
        IEnumerable<T> GetModules<T>() where T : IOregoModule;

        /// <summary>
        ///     <para>Gets a module of required type.</para>
        /// </summary>
        /// <typeparam name="T">Required type.</typeparam>
        /// <returns>A required module.</returns>
        T GetModule<T>() where T : IOregoModule;
    }
}