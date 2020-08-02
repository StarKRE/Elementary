using System;
using System.Collections;
using ElementaryFramework.Util;

namespace ElementaryFramework.App
{
    public interface ISynchronizableRepository<out T> : IAsyncRepository
    {
        event Action<T> OnDataSynchronizedEvent;

        IEnumerator SynchronizeDataAsync(Reference<bool> isSuccess);
    }
}