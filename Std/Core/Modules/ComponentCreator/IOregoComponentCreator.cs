using System;
using System.Collections.Generic;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Creates system components in your framework.</para>
    /// </summary>
    public interface IOregoComponentCreator : IOregoModule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requiredType"></param>
        /// <param name="filter"></param>
        /// <typeparam name="T">Required interface type. This type must:
        ///    1.) Derives from interface <see cref="IOregoComponent"/>
        ///    2.) Annotates with attribute <see cref="OregoContext"/>
        ///    3.) Implementation must have the default constructor.
        /// </typeparam>
        /// <returns>Set of components.</returns>
        T CreateComponent<T>(Type requiredType, Func<Type, bool> filter = null)
            where T : IOregoComponent;

        /// <summary>
        ///     <para>Creates a set of required components by type.</para>
        /// </summary>
        /// <param name="filter">filter function.</param>
        /// <typeparam name="T">Required interface type. This type must:
        ///    1.) Derives from interface <see cref="IOregoComponent"/>
        ///    2.) Annotates with attribute <see cref="OregoContext"/>
        ///    3.) Implementations must have the default constructor.
        /// </typeparam>
        /// <returns>Set of components.</returns>
        IEnumerable<T> CreateComponents<T>(Func<Type, bool> filter = null)
            where T : IOregoComponent;
    }
}