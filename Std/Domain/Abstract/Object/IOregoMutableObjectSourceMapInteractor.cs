using System;

namespace OregoFramework.Domain
{
    public interface IOregoMutableObjectSourceMapInteractor<in TKey, TValue> : IOregoObjectSourceMapInteractor<TKey, TValue>
    {
        event Action<object, TValue> OnObjectAddedEvent;

        event Action<object, TValue> OnObjectRemovedEvent;
        
        void NotifyAboutObjectAdded(object sender, TValue obj);

        void NotifyAboutObjectRemoved(object sender, TValue obj);
    }
}