using System.Collections.Generic;
using OregoFramework.Game;
using OregoFramework.Repo;

namespace OregoFramework.Domain
{
    public abstract class OregoStandardShopInteractor<TProductObject, TProductData> :
        OregoStandardObjectSourceMapInteractor<
            string, TProductObject, IOregoStandardProductRepository<TProductData>, TProductData
        >
        where TProductObject : OregoProductObject
        where TProductData : IOregoProductData
    {
        protected readonly Dictionary<string, IOregoProductInfo> productInfoMap;

        protected OregoStandardShopInteractor()
        {
            this.productInfoMap = new Dictionary<string, IOregoProductInfo>();
        }

        #region OnCreate

        public override void OnCreate()
        {
            base.OnCreate();
            var productInfoSet = this.LoadProductInfoSet();
            foreach (var productInfo in productInfoSet)
            {
                var productId = productInfo.id;
                this.productInfoMap[productId] = productInfo;
            }
        }

        protected abstract IEnumerable<IOregoProductInfo> LoadProductInfoSet();

        #endregion

        #region SetupProducts

        protected sealed override TProductObject SetupObject(TProductData data)
        {
            var productId = data.id;
            var productInfo = this.productInfoMap[productId];
            var productObject = this.BuildProductObject(productInfo, data);
            return productObject;
        }

        protected abstract TProductObject BuildProductObject(IOregoProductInfo productInfo,
            TProductData data);

        #endregion
    }
}