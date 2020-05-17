using System.Collections;

namespace OregoFramework.Repo
{
    public interface IOregoOnEndSessionAsyncListener
    {
        IEnumerator OnEndSessionAsync();
    }
}