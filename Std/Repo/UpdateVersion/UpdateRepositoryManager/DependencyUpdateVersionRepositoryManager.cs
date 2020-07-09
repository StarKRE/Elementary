using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OregoFramework.Util;

namespace OregoFramework.Repo
{
    public sealed class DependencyUpdateVersionRepositoryManager : RepoElement,
        IUpdateVersionRepositoryManager
    {
        private readonly Dictionary<Type, HashSet<IUpdateVersionRepository>> dependencyRepositoryMap;

        private IRepositoryLayer root;

        public DependencyUpdateVersionRepositoryManager()
        {
            this.dependencyRepositoryMap = new Dictionary<Type, HashSet<IUpdateVersionRepository>>();
        }

        #region OnPrepare

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.root = this.GetRepositoryLayer<IRepositoryLayer>();
            this.InitDependencyMap();
        }

        private void InitDependencyMap()
        {
            var repositories = this.root.GetRepositories<IUpdateVersionRepository>();
            foreach (var repository in repositories)
            {
                var repositoryType = repository.GetType();
                var dependRepositories = new HashSet<IUpdateVersionRepository>();
                this.dependencyRepositoryMap[repositoryType] = dependRepositories;
            }
        }

        #endregion

        public void AddDependency(Type targetRepositoryType, IUpdateVersionRepository dependencyRepository)
        {
            var repositoryDependencies = this.dependencyRepositoryMap[targetRepositoryType];
            repositoryDependencies.Add(dependencyRepository);
        }

        public IEnumerator UpdateVersionInRepositories()
        {
            var root = this.GetRepositoryLayer<IRepositoryLayer>();
            var repositories = root.GetRepositories<IUpdateVersionRepository>();
            var checkingRepositories = new HashSet<IUpdateVersionRepository>(repositories);
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