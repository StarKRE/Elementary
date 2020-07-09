using System;

namespace OregoFramework.Domain
{
    public interface IItemInteractor<T> : IInteractor
    {
        event Action<object, T> OnItemChangedEvent;

        void NotifyAboutObjectChanged(object sender, T item);
    }
}