using System.Collections;

namespace ElementaryFramework.App
{
    public interface IVersionUpdater : IRepoElement
    {
        IEnumerator CheckForUpdates();
    }
}