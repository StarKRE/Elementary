using System.Collections.Generic;
using System.Data;
using System.Linq;
using OregoFramework.Repo;
using UnityEngine;

namespace OregoFramework.Domain
{
    public abstract class
        StandardItemMapInteractor<K, T, TRepository, TData> :
            StandardItemInteractor<T, TRepository, IEnumerable<TData>>,
            IItemMapInteractor<K, T>
        where TRepository : IReadyRepository<IEnumerable<TData>>
    {
        protected readonly Dictionary<K, T> objectMap;

        protected StandardItemMapInteractor()
        {
            this.objectMap = new Dictionary<K, T>();
        }

        #region Setup

        protected sealed override void Setup(IEnumerable<TData> dataSet)
        {
            foreach (var data in dataSet)
            {
                var tObject = this.SetupItem(data);
                var id = this.GetItemId(tObject);
                this.objectMap[id] = tObject;
            }
        }

        protected abstract T SetupItem(TData data);

        protected abstract K GetItemId(T item);

        #endregion

        public T GetItem(K key)
        {
            return this.objectMap[key];
        }

        public IEnumerable<T> GetItems()
        {
            return this.objectMap.Values.ToList();
        }

        public int GetItemCount()
        {
            return this.objectMap.Count;
        }
    }
}