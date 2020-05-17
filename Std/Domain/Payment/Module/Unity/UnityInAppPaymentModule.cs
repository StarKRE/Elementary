#if UNITY_PURCHASING
using System;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine.Purchasing;

namespace Orego.Domain
{
    public abstract class UnityInAppPaymentModule : IPaymentModule, IStoreListener
    {
        #region Delegate

        public delegate void PurchaseCallback(UnityPaymentResult result);

        #endregion

        #region Event

        public event Action OnInitializeSucceedEvent;

        public event Action<InitializationFailureReason> OnInitializeFailedEvent;

        #endregion

        private IStoreController storeController;

        private IExtensionProvider storeExtensionProvider;

        private IProduct currentPurchasingProduct;

        private Action<PaymentResult> currentPurchasingCallback;

        public virtual bool isPurchasing { get; protected set; }

        protected virtual bool isInitialized
        {
            get { return this.storeController != null && this.storeExtensionProvider != null; }
        }

        #region Initialize

        public void Initialize()
        {
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            var consumableProducts = this.LoadConsumableProducts();
            foreach (var product in consumableProducts)
            {
                builder.AddProduct(product.inAppCode, OSPlatform.ProductType.Consumable);
            }

            var nonConsumableProducts = this.LoadNonConsumableProducts();
            foreach (var product in nonConsumableProducts)
            {
                builder.AddProduct(product.inAppCode, OSPlatform.ProductType.NonConsumable);
            }

            var subcribtionProducts = this.LoadSubcribtionProducts();
            foreach (var product in subcribtionProducts)
            {
                builder.AddProduct(product.inAppCode, OSPlatform.ProductType.Subscription);
            }

            UnityPurchasing.Initialize(this, builder);
        }

        protected virtual IEnumerable<IConsumableInAppProcut> LoadConsumableProducts() 
        {
            return new IConsumableInAppProcut[] { };
        }

        protected virtual IEnumerable<INonConsumableInAppProduct> LoadNonConsumableProducts()
        {
            return new INonConsumableInAppProduct[] { };
        }

        protected virtual IEnumerable<ISubcriptionInAppProduct> LoadSubcribtionProducts()
        {
            return new ISubcriptionInAppProduct[] { };
        }

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            this.storeController = controller;
            this.storeExtensionProvider = extensions;
            this.OnInitializeSucceedEvent?.Invoke();
        }

        public void OnInitializeFailed(InitializationFailureReason error)
        {
            this.OnInitializeFailedEvent?.Invoke(error);
        }

        #endregion

        #region Pay

        public void Pay(PaymentParams paymentParams, Action<PaymentResult> callback)
        {
            this.CheckInitialization();
            if (this.isPurchasing)
            {
                throw new Exception("Purchaser is already purchasing a product!");
            }

            var product = paymentParams.product;
            if (!(product is IInAppProduct inAppProduct))
            {
                throw new Exception("Can not purchase not inApp product!");
            }

            var inAppCode = inAppProduct.inAppCode;
            var onlineProduct = this.storeController.products.WithID(inAppCode);
            if (this.CanPurchase(inAppProduct, onlineProduct))
            {
                var paymentResult = new UnityPaymentResult
                {
                    message = UnityPaymentResultMessages.NOT_AVAILABLE_FOR_PURCHASE,
                    isSuccessful = false
                };
                callback?.Invoke(paymentResult);
                return;
            }

            this.isPurchasing = true;
            this.currentPurchasingCallback = callback;
            this.storeController.InitiatePurchase(onlineProduct);
        }

        protected bool CanPurchase(IInAppProduct inAppProduct, UnityEngine.Purchasing.Product onlineProduct)
        {
            return onlineProduct.availableToPurchase &&
                   (inAppProduct is IConsumableProduct || !onlineProduct.hasReceipt);
        }

        public void OnPurchaseFailed(UnityEngine.Purchasing.Product product, PurchaseFailureReason failureReason)
        {
            var callback = this.currentPurchasingCallback;
            this.currentPurchasingCallback = null;
            this.isPurchasing = false;
            var result = new UnityPaymentResult
            {
                isSuccessful = false,
                failureReason = failureReason
            };
            callback?.Invoke(result);
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
        {
            var callback = this.currentPurchasingCallback;
            this.currentPurchasingCallback = null;
            this.isPurchasing = false;
            var paymentResult = new UnityPaymentResult
            {
                isSuccessful = true
            };
            callback?.Invoke(paymentResult);
            return PurchaseProcessingResult.Complete;
        }

        #endregion

        #region RequestIsAvailableForPurchase

        public virtual bool RequestIsAvailableForPurchase(IInAppProduct inAppProduct)
        {
            this.CheckInitialization();
            var inAppCode = inAppProduct.inAppCode;
            var onlineProduct = this.storeController.products.WithID(inAppCode);
            if (onlineProduct == null)
            {
                throw new Exception($"Product {inAppProduct.inAppCode} not found!");
            }

            if (inAppProduct is IConsumableProduct)
            {
                return true;
            }

            var isBought = onlineProduct.hasReceipt;
            return !isBought;
        }

        #endregion

        #region RequestPrice

        public string RequestPrice(IInAppProduct inAppProduct)
        {
            this.CheckInitialization();
            var onlineProduct = storeController.products.WithID(inAppProduct.inAppCode);
            if (onlineProduct == null)
            {
                throw new Exception($"Product {inAppProduct.inAppCode} not found!");
            }

            return onlineProduct.metadata.localizedPriceString;
        }

        #endregion

        protected virtual void CheckInitialization()
        {
            if (!this.isInitialized)
            {
                throw new Exception("Purchaser is not initialized!");
            }
        }

        public interface IConsumableInAppProcut : IInAppProduct, IConsumableProduct
        {
        }

        public interface INonConsumableInAppProduct : IInAppProduct, INonConsumableProduct
        {
        }

        public interface ISubcriptionInAppProduct : IInAppProduct, ISubscriptionProduct
        {
        }
    }
}
#endif