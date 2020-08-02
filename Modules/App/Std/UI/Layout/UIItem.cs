using System;

namespace ElementaryFramework.App
{
    public class UIItem<T> : UIElement
    {
        public T currentItem { get; protected set; }

        public virtual void SetItem(T item)
        {
            if (item == null)
            {
                throw new Exception("Input item is null!");
            }

            this.currentItem = item;
            this.UpdateItem();
        }

        public virtual void UpdateItem()
        {
        }
    }
}