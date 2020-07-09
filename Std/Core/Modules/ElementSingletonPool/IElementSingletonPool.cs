using System.Collections.Generic;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Create main element singletons in your framework system.</para>
    /// </summary>
    public interface IElementSingletonPool : IModule
    {
        HashSet<ISingletonElement> singletons { get; }

        /// <summary>
        ///     <para>Load singletons.</para>
        /// </summary>
        void LoadSingletons();
    }
}