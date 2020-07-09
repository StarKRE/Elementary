using System;

namespace OregoFramework.Domain
{
    public interface IMutableItemMapInteractor<in K, T> : IItemMapInteractor<K, T>
    {
        event Action<object, T> OnItemAddedEvent;

        event Action<object, T> OnItemRemovedEvent;
        
        void NotifyAboutItemAdded(object sender, T item);

        void NotifyAboutItemRemoved(object sender, T item);
    }
}