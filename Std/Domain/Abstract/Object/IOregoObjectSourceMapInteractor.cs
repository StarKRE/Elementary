using System.Collections.Generic;

namespace OregoFramework.Domain
{
    public interface IOregoObjectSourceMapInteractor<in TKey, TValue> : IOregoObjectSourceInteractor<TValue>
    {
        TValue GetObject(TKey key);

        IEnumerable<TValue> GetObjects();

        int GetObjectCount();
    }
}