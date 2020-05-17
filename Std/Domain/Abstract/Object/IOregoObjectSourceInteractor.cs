using System;

namespace OregoFramework.Domain
{
    public interface IOregoObjectSourceInteractor<T> : IOregoInteractor
    {
        event Action<object, T> OnObjectChangedEvent;

        void NotifyAboutObjectChanged(object sender, T obj);
    }
}