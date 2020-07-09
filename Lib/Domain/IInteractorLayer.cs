using System.Collections.Generic;
using OregoFramework.Core;

namespace OregoFramework.Domain
{
    /// <summary>
    /// <para>Base interface layer of domain controllers to work with business logic.</para>
    /// </summary>
    public interface IInteractorLayer : IElement
    {
        /// <summary>
        ///     <para>Gets required interactor.</para>
        /// </summary>
        /// <typeparam name="T">Required type of interactor.</typeparam>
        /// <returns>Required interactor reference.</returns>
        T GetInteractor<T>() where T : IInteractor;

        /// <summary>
        ///     <para>Gets required interactors.</para>
        /// </summary>
        /// <typeparam name="T">Required type of interactor.</typeparam>
        /// <returns>Required interactor set.</returns>
        IEnumerable<T> GetInteractors<T>() where T : IInteractor;
    }
}