namespace OregoFramework.Repo
{
    /// <summary>
    /// <para>Base abstract implementation of repository.</para>
    /// </summary>.
    public abstract class OregoRepository : OregoRepositoryComponent, IOregoRepository
    {
        public abstract bool isActiveSession { get; protected set; }
    }
}