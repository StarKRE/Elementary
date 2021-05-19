using System.Collections.Generic;

namespace Elementary
{
    /// <summary>
    ///     <para>An element system contract.</para>
    ///     <para>Creates elements by abstract type or interface.</para>
    ///     <para>Maintains the root elements and provides access to them.</para>
    /// </summary>
    public interface IElementContext
    {
        /// <summary>
        ///     <para>Creates a new element instance of "T".</para>
        /// </summary>
        /// <typeparam name="T">Type or interface.</typeparam>
        T CreateElement<T>() where T : IElement;

        /// <summary>
        ///     <para>Creates element instances derived from "T.</para>
        /// </summary>
        /// <typeparam name="T">Type or interface.</typeparam>
        IEnumerable<T> CreateElements<T>() where T : IElement;

        /// <summary>
        ///     <para>Gets a root element of "T".</para>
        /// </summary>
        /// 
        /// <typeparam name="T">Type or interface.</typeparam>
        T GetRootElement<T>();

        /// <summary>
        ///     <para>Gets root elements derived from "T".</para>
        /// </summary>
        /// <typeparam name="T">Type or interface.</typeparam>
        IEnumerable<T> GetRootElements<T>();
    }
}