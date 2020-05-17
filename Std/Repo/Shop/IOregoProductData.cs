using OregoFramework.Util;

namespace OregoFramework.Repo
{
    public interface IOregoProductData : ICloneable<IOregoProductData>
    {
        string id { get; set; }
    }
}