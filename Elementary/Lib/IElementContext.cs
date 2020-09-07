using System;
using System.Collections.Generic;

namespace Elementary
{
    /// <summary>
    ///     <para>A system that consists of elements.</para>
    /// </summary>
    public interface IElementContext
    {
        /// <summary>
        ///     <para>Initializes this system.
        ///     Use this method to instantiate elements.</para>
        /// </summary>
        void Initialize();

        /// <summary>
        ///     <para>Finalizes this system.
        ///     Use this method to dispose resources from this context.</para>
        /// </summary>
        void Terminate();

        /// <summary>
        ///     <para>Instantiates a new instance of element.
        ///     Use this method instead the default constructor.</para>
        /// </summary>
        /// <typeparam name="T">Abstract type.</typeparam>
        /// <param name="implementationType">Target type whose instance will be created.</param>
        /// <returns>A new instance of element.</returns>
        T CreateElement<T>(Type implementationType) where T : IElement;

        /// <summary>
        ///     <para>Instantiates a new "T" element group.
        ///     The group consists of unique elements derived from "T".</para>
        /// </summary>
        /// <typeparam name="T">Base element type.</typeparam>
        /// <returns>Unique element instances inherited from "T".</returns>
        IEnumerable<T> CreateElements<T>() where T : IElement;

        /// <summary>
        ///     <para>Returns a root element of this context.</para>
        /// </summary>
        /// <typeparam name="T">The root element type.</typeparam>
        /// <returns>Reference.</returns>
        T GetRootElement<T>() where T : IRootElement;

        /// <summary>
        ///     <para>Returns a group of required root elements.</para>
        /// </summary>
        /// <typeparam name="T">Base elemeny type.</typeparam>
        /// <returns>A group of root elements inherited from "T".</returns>
        IEnumerable<T> GetRootElements<T>() where T : IRootElement;
    }
}