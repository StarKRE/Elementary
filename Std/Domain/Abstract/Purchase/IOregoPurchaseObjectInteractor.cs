using System;

namespace OregoFramework.Domain
{
    public interface IOregoPurchaseObjectInteractor<T> : IOregoInteractor
    {
        event Action<object, T> OnObjectPurchasedEvent; 
        
        void PurchaseObject(object sender, T obj);

        bool CanPurchaseObject(T product);
    }
}