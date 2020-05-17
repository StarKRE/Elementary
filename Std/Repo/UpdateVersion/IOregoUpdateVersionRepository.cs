using System.Collections;
using OregoFramework.Util;

namespace OregoFramework.Repo
{
    public interface IOregoUpdateVersionRepository : IOregoRepository
    {
        IEnumerator OnUpdateVersionAsync(Reference<bool> isUpdated);
    }
}