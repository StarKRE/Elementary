using System;
using OregoFramework.Util;

namespace OregoFramework.Domain
{
    public abstract class OregoDomainRewarder : OregoDomainComponent, IRewarder
    {
        public event Action<object, RewardResults> OnRewardReceivedEvent;

        public abstract bool CanReward(IReward reward);

        public abstract void Reward(object sender, IReward reward);

        protected void NotifyAboutRewardReceived(object sender, RewardResults results)
        {
            this.OnRewardReceivedEvent?.Invoke(sender, results);
        }
    }
}