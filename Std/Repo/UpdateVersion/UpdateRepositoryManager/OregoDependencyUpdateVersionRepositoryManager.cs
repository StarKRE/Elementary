using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OregoFramework.Util;

namespace OregoFramework.Repo
{
    public sealed class OregoDependencyUpdateVersionRepositoryManager : OregoRepositoryComponent,
        IOregoUpdateVersionRepositoryManager
    {
        private readonly Dictionary<Type, HashSet<IOregoUpdateVersionRepository>> dependencyRepositoryMap;

        private IOregoRepositoryLayer root;

        public OregoDependencyUpdateVersionRepositoryManager()
        {
            this.dependencyRepositoryMap = new Dictionary<Type, HashSet<IOregoUpdateVersionRepository>>();
        }

        #region OnPrepare

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.root = this.GetRepositoryLayer<IOregoRepositoryLayer>();
            this.InitDependencyMap();
        }

        private void InitDependencyMap()
        {
            var repositories = this.root.GetRepositories<IOregoUpdateVersionRepository>();
            foreach (var repository in repositories)
            {
                var repositoryType = repository.GetType();
                var dependRepositories = new HashSet<IOregoUpdateVersionRepository>();
                this.dependencyRepositoryMap[repositoryType] = dependRepositories;
            }
        }

        #endregion

        public void AddDependency(Type targetRepositoryType, IOregoUpdateVersionRepository dependencyRepository)
        {
            var repositoryDependencies = this.dependencyRepositoryMap[targetRepositoryType];
            repositoryDependencies.Add(dependencyRepository);
        }

        public IEnumerator UpdateVersionInRepositories()
        {
            var root = this.GetRepositoryLayer<IOregoRepositoryLayer>();
            var repositories = root.GetRepositories<IOregoUpdateVersionRepository>();
            var checkingRepositories = new HashSet<IOregoUpdateVersionRepository>(repositories);
            while (checkingRepositories.IsNotEmpty())
            {
                var nextRepository = checkingRepositories.First();
                var isUpdatedReference = new Reference<bool>();
                yield return nextRepository.OnUpdateVersionAsync(isUpdatedReference);
                if (isUpdatedReference.value)
                {
                    var updatedRepositoryType = nextRepository.GetType();
                    var dependencyRepositories = this.dependencyRepositoryMap[updatedRepositoryType];
                    checkingRepositories.AddRange(dependencyRepositories);
                }
            }
        }
    }
}