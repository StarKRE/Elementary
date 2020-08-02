namespace ElementaryFramework.App
{
    /// <summary>
    ///     <para>Base interface of repository for work with data.</para>
    /// </summary>
    public interface IRepository : IRepoElement
    {
        /// <summary>
        ///     <para>Defines is session started or not.</para>
        /// </summary>
        bool isActiveSession { get; }
    }
}