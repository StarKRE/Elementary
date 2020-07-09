using System;

namespace OregoFramework.Repo
{
    public interface IReadyRepository<out T> : IAsyncRepository
    {
        event Action<T> OnDataReadyEvent;
    }
}