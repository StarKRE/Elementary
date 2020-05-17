using System;

namespace OregoFramework.Util
{
    public interface IRewarder
    {
        event Action<object, RewardResults> OnRewardReceivedEvent;
        
        bool CanReward(IReward reward);
        
        void Reward(object sender, IReward reward);
    }
}