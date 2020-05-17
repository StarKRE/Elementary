using System.Collections.Generic;

namespace OregoFramework.Repo
{
    public interface IOregoStandardProductRepository<T> :
        IOregoReadyDataRepository<IEnumerable<T>>
        where T : IOregoProductData
    {
        T GetProductData(string id);

        IEnumerable<T> GetProductDataSet();

        void SetProductData(T productData);

        void SetProductDataSet(IEnumerable<T> productDataSet);
    }
}