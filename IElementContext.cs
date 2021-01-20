using System;
using System.Collections.Generic;

namespace Elementary
{
    /// <summary>
    ///     <para>A system that contains elements.</para>
    /// </summary>
    public interface IElementContext
    {
        /// <summary>
        ///     <para>Initializes this system.</para>
        ///     <para>Use this method to instantiate elements.</para>
        /// </summary>
        void Initialize();

        /// <summary>
        ///     <para>Finalizes this system.</para>
        ///     <para>Use this method to destroy elements.</para>
        /// </summary>
        void Terminate();

        /// <summary>
        ///     <para>Create a new element instance.</para>
        ///     <para>Use this method instead the default constructor.</para>
        ///     <para>Don't use constructors to instantiate an element instance!</para>
        /// </summary>
        /// 
        /// <param name="implementationType">Specific type.</param>
        /// <returns>A new instance of element.</returns>
        T CreateElement<T>(Type implementationType) where T : IElement;

        /// <summary>
        ///     <para>Instantiates a new set of unique elements derived from "T".</para>
        /// </summary>
        /// 
        /// <typeparam name="T">Base element type.</typeparam>
        /// <returns>Unique element instances inherited from "T".</returns>
        IEnumerable<T> CreateElements<T>() where T : IElement;

        /// <summary>
        ///     <para>Returns a root element of this context.</para>
        /// </summary>
        /// 
        /// <typeparam name="T">The root element type.</typeparam>
        /// <returns>Instance.</returns>
        T GetRootElement<T>() where T : IRootElement;

        /// <summary>
        ///     <para>Returns a set of root elements derived from "T".</para>
        /// </summary>
        /// 
        /// <typeparam name="T">Base elemeny type.</typeparam>
        /// <returns>A group of root elements inherited from "T".</returns>
        IEnumerable<T> GetRootElements<T>() where T : IRootElement;
    }
}