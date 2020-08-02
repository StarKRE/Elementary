using System.Collections;
using ElementaryFramework.Util;

namespace ElementaryFramework.App
{
    public abstract class BaseUpdateVersionRepositoryManager : RepoElement,
        IUpdateVersionRepositoryManager
    {
        public IEnumerator UpdateVersionInRepositories()
        {
            var repositories = this.repositoryLayer.GetRepositories<IUpdateVersionRepository>();
            var isRequiredUpdate = true;
            while (isRequiredUpdate)
            {
                isRequiredUpdate = false;
                foreach (var repository in repositories)
                {
                    var isUpdatedReference = new Reference<bool>();
                    yield return repository.OnUpdateVersionAsync(isUpdatedReference);
                    if (isUpdatedReference.value)
                    {
                        isRequiredUpdate = true;
                        break;
                    }
                }
            }
        }
    }
}