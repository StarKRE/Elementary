using System;
using System.Collections.Generic;

namespace Elementary
{
    /// <summary>
    ///     <para>Element system. Responsibles for all elements.</para>
    /// </summary>
    public interface IElementContext
    {
        /// <summary>
        ///     <para>Initializes system. Use this method before work.</para>
        /// </summary>
        void Initialize();

        /// <summary>
        ///     <para>Finalizes system. Dispose resources in context.</para>
        /// </summary>
        void Terminate();

        /// <summary>
        ///     <para>Creates a new element like a default constructor.</para>
        /// </summary>
        /// <param name="targetType">Implementation type.</param>
        /// <typeparam name="T">Interface type</typeparam>
        /// <returns>New instance.</returns>
        T CreateElement<T>(Type targetType) where T : IElement;

        /// <summary>
        ///     <para>Creates a new element group.</para>
        /// </summary>
        /// <typeparam name="T">Interface type.</typeparam>
        /// <returns>A group of new elements inherited from "T"</returns>
        IEnumerable<T> CreateElements<T>() where T : IElement;

        /// <summary>
        ///     <para>Returns a root element in hierarchy.</para>
        /// </summary>
        /// <typeparam name="T">Root type</typeparam>
        /// <returns>Reference.</returns>
        T GetRootElement<T>() where T : IRootElement;

        /// <summary>
        ///     <para>Returns a group of required root elements.</para>
        /// </summary>
        /// <typeparam name="T">Interface type.</typeparam>
        /// <returns>A group of root elements.</returns>
        IEnumerable<T> GetRootElements<T>() where T : IRootElement;
    }
}