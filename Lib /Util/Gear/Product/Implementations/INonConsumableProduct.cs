namespace OregoFramework.Util
{
    public interface INonConsumableProduct : IProduct
    {
        bool isPurchased { get; }
    }
}