using System;
using System.Collections.Generic;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Creates system elements in your framework.</para>
    /// </summary>
    public interface IElementCreator : IModule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requiredType"></param>
        /// <param name="filter"></param>
        /// <typeparam name="T">Required interface type. This type must:
        ///    1.) Derives from interface <see cref="IElement"/>
        ///    2.) Annotates with attribute <see cref="OregoContext"/>
        ///    3.) Implementation must have the default constructor.
        /// </typeparam>
        /// <returns>Set of elements.</returns>
        T CreateElement<T>(Type requiredType, Func<Type, bool> filter = null)
            where T : IElement;

        /// <summary>
        ///     <para>Creates a set of required elements by type.</para>
        /// </summary>
        /// <param name="filter">filter function.</param>
        /// <typeparam name="T">Required interface type. This type must:
        ///    1.) Derives from interface <see cref="IElement"/>
        ///    2.) Annotates with attribute <see cref="OregoContext"/>
        ///    3.) Implementations must have the default constructor.
        /// </typeparam>
        /// <returns>Set of elements.</returns>
        IEnumerable<T> CreateElements<T>(Func<Type, bool> filter = null)
            where T : IElement;
    }
}