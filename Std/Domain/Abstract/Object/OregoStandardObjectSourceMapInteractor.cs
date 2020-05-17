using System.Collections.Generic;
using System.Linq;
using OregoFramework.Repo;
using UnityEngine;

namespace OregoFramework.Domain
{
    public abstract class
        OregoStandardObjectSourceMapInteractor<TKey, TObject, TRepository, TData> :
            OregoStandardObjectSourceInteractor<TObject, TRepository, IEnumerable<TData>>,
            IOregoObjectSourceMapInteractor<TKey, TObject>
        where TRepository : IOregoReadyDataRepository<IEnumerable<TData>>
    {
        protected readonly Dictionary<TKey, TObject> objectMap;

        protected OregoStandardObjectSourceMapInteractor()
        {
            this.objectMap = new Dictionary<TKey, TObject>();
        }

        #region Setup

        protected sealed override void Setup(IEnumerable<TData> data)
        {
            var itemDataSet = data;
            foreach (var itemData in itemDataSet)
            {
                var tObject = this.SetupObject(itemData);
                var id = this.GetObjectId(tObject);
                this.objectMap[id] = tObject;
            }
        }

        protected abstract TObject SetupObject(TData data);

        protected abstract TKey GetObjectId(TObject tObject);

        #endregion

        public TObject GetObject(TKey key)
        {
            return this.objectMap[key];
        }

        public IEnumerable<TObject> GetObjects()
        {
            return this.objectMap.Values.ToList();
        }

        public int GetObjectCount()
        {
            return this.objectMap.Count;
        }
    }
}