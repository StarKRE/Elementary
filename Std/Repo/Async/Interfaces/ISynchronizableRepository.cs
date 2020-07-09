using System;
using System.Collections;
using OregoFramework.Util;

namespace OregoFramework.Repo
{
    public interface ISynchronizableRepository<out T> : IAsyncRepository
    {
        event Action<T> OnDataSynchronizedEvent;

        IEnumerator SynchronizeDataAsync(Reference<bool> isSuccess);
    }
}