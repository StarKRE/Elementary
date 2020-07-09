namespace OregoFramework.Repo
{
    /// <summary>
    /// <para>Base abstract implementation of repository.</para>
    /// </summary>.
    public abstract class Repository : RepoElement, IRepository
    {
        public abstract bool isActiveSession { get; protected set; }
    }
}