using System.Collections;
using OregoFramework.Util;

namespace OregoFramework.Repo
{
    public abstract class OregoBaseUpdateVersionRepositoryManager : OregoRepositoryComponent,
        IOregoUpdateVersionRepositoryManager
    {
        public IEnumerator UpdateVersionInRepositories()
        {
            var root = this.GetRepositoryLayer<IOregoRepositoryLayer>();
            var repositories = root.GetRepositories<IOregoUpdateVersionRepository>();
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