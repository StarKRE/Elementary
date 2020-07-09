using System.Collections;
using OregoFramework.Util;

namespace OregoFramework.Repo
{
    public interface IUpdateVersionRepository : IRepository
    {
        IEnumerator OnUpdateVersionAsync(Reference<bool> isUpdated);
    }
}