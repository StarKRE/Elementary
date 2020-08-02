using System.Collections;
using ElementaryFramework.Util;

namespace ElementaryFramework.App
{
    public interface IUpdateVersionRepository : IRepository
    {
        IEnumerator OnUpdateVersionAsync(Reference<bool> isUpdated);
    }
}