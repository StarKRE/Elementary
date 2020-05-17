using System.Collections;

namespace OregoFramework.Repo
{
    public interface IOregoOnBeginSessionAsyncListener
    {
        IEnumerator OnBeginSessionAsync();
    }
}