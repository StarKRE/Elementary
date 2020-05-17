using System;

namespace OregoFramework.Domain
{
    public interface IOregoSelectObjectInteractor<T> : IOregoInteractor
    {
        event Action<object, T> OnSelectedObjectChangedEvent;

        void SelectObject(object sender, T obj);

        bool IsSelectedObject(T obj);
    }
}