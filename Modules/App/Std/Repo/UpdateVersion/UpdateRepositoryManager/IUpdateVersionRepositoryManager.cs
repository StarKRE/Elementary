using System.Collections;

namespace ElementaryFramework.App
{
    public interface IUpdateVersionRepositoryManager : IRepoElement
    {
        IEnumerator UpdateVersionInRepositories();
    }
}