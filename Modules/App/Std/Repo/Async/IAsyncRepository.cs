using System.Collections;

namespace ElementaryFramework.App
{
    public interface IAsyncRepository : IRepository
    {
        IEnumerator OnBeginSession();

        IEnumerator OnEndSession();
    }
}