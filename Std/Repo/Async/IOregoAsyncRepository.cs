using System.Collections;

namespace OregoFramework.Repo
{
    public interface IOregoAsyncRepository : IOregoRepository
    {
        IEnumerator OnBeginSession();

        IEnumerator OnEndSession();
    }
}