using System;
using System.Collections;
using OregoFramework.Util;

namespace OregoFramework.Repo
{
    public interface IOregoAsyncSynchronizeRepository<out T> : IOregoAsyncRepository
    {
        event Action<T> OnDataSynchronizedEvent;

        IEnumerator SynchronizeDataAsync(Reference<bool> isSuccess);
    }
}