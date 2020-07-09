using System;
using System.Collections.Generic;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Keeps available element types in the framework context.</para>
    /// </summary>
    public interface IElementTypePool : IModule
    {
        HashSet<Type> elementTypes { get; }
        
        /// <summary>
        /// <para>Loads available types.</para>
        /// </summary>
        void LoadTypes();
    }
}