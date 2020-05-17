using OregoFramework.Core;

namespace OregoFramework.Repo
{
    /// <summary>
    ///     <para>Base interface of repository for work with data.</para>
    /// </summary>
    public interface IOregoRepository : IOregoComponent
    {
        /// <summary>
        ///     <para>Defines is session started or not.</para>
        /// </summary>
        bool isActiveSession { get; }
    }
}