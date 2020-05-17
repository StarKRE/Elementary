using System.Collections.Generic;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Create main component singletons in your framework system.</para>
    /// </summary>
    public interface IOregoComponentSingletonManager : IOregoModule
    {
        HashSet<IOregoSingletonComponent> singletons { get; }

        /// <summary>
        ///     <para>Creates and initializes singletons.</para>
        /// </summary>
        void CreateSingletons();
    }
}