using System.Collections;

namespace OregoFramework.Repo
{
    public interface IOnBeginSessionAsyncListener
    {
        IEnumerator OnBeginSessionAsync();
    }
}