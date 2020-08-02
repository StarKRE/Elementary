using ElementaryFramework.Core;

namespace ElementaryFramework.App
{
    /// <summary>
    ///    <para>Architectural application pattern with abstract layers.</para>
    /// </summary>
    public interface IApplication : IRootElement
    {
        /// <summary>
        ///     <para>Works with network.</para>
        /// </summary>
        IClientLayer clientLayer { get; }
        
        /// <summary>
        ///     <para>Works with local storage.</para>
        /// </summary>
        IDatabaseLayer databaseLayer { get; }
        
        /// <summary>
        ///     <para>Works with data.</para>
        /// </summary>
        IRepositoryLayer repositoryLayer { get; }

        /// <summary>
        ///     <para>Works with business logic.</para>
        /// </summary>
        IInteractorLayer interactorLayer { get; }
    }
}