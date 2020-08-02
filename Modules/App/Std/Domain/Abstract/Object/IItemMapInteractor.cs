using System.Collections.Generic;

namespace ElementaryFramework.App
{
    public interface IItemMapInteractor<in K, T> : IItemInteractor<T>
    {
        T GetItem(K key);

        IEnumerable<T> GetItems();

        int GetItemCount();
    }
}