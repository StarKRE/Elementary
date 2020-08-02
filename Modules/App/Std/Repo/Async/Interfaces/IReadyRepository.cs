using System;

namespace ElementaryFramework.App
{
    public interface IReadyRepository<out T> : IAsyncRepository
    {
        event Action<T> OnDataReadyEvent;
    }
}