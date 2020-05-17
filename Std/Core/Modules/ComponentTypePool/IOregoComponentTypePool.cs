using System;
using System.Collections.Generic;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Keeps available component types in the framework context.</para>
    /// </summary>
    public interface IOregoComponentTypePool : IOregoModule
    {
        HashSet<Type> componentTypes { get; }
        
        /// <summary>
        /// <para>Loads available types.</para>
        /// </summary>
        void LoadTypes();
    }
}