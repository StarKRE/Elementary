using OregoFramework.Game;
using OregoFramework.Util;

namespace OregoFramework.Domain
{
    public abstract class OregoProductObject :
        ComposableObject<IOregoProductInfo, IOregoProductObjectState>, IProduct
    {
        protected OregoProductObject(IOregoProductInfo info, IOregoProductObjectState state) :
            base(info, state)
        {
        }
    }
}