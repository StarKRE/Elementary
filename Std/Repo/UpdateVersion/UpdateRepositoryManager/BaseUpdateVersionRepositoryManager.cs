using System.Collections;
using OregoFramework.Util;

namespace OregoFramework.Repo
{
    public abstract class BaseUpdateVersionRepositoryManager : RepoElement,
        IUpdateVersionRepositoryManager
    {
        public IEnumerator UpdateVersionInRepositories()
        {
            var root = this.GetRepositoryLayer<IRepositoryLayer>();
            var repositories = root.GetRepositories<IUpdateVersionRepository>();
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