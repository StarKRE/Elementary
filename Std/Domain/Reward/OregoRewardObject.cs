using OregoFramework.Game;
using OregoFramework.Util;

namespace OregoFramework.Domain
{
    public abstract class OregoRewardObject :
        ComposableObject<IOregoRewardInfo, IOregoRewardObjectState>
    {
        protected OregoRewardObject(IOregoRewardInfo info, IOregoRewardObjectState state) :
            base(info, state)
        {
        }
    }
}