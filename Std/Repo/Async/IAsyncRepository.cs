using System.Collections;

namespace OregoFramework.Repo
{
    public interface IAsyncRepository : IRepository
    {
        IEnumerator OnBeginSession();

        IEnumerator OnEndSession();
    }
}