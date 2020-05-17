using System;

namespace OregoFramework.Repo
{
    public interface IOregoReadyDataRepository<out T> : IOregoAsyncRepository
    {
        event Action<T> OnDataReadyEvent;

        // void AddOnReadyListener(Action<T> onReadyAction);
        //
        // void RemoveOnReadyListener(Action<T> onReadyAction);
    }
}