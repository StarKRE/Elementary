using System.Collections.Generic;

namespace OregoFramework.Util
{
    public interface IRewardSystem
    {
        IEnumerable<T> GetRewarders<T>() where T : IRewarder;

        T GetRewarder<T>() where T : IRewarder;
    }
}