using System.Collections;

namespace OregoFramework.Repo
{
    public interface IOnEndSessionAsyncListener
    {
        IEnumerator OnEndSessionAsync();
    }
}