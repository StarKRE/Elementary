using OregoFramework.Util;

namespace OregoFramework.Domain
{
    public abstract class OregoBaseDomainRewarder<T> : OregoDomainRewarder where T : IReward
    {
        public override bool CanReward(IReward reward)
        {
            return reward is T;
        }

        public override void Reward(object sender, IReward reward)
        {
            if (reward is T)
            {
                this.Reward(sender, (T) reward);
            }
        }

        protected abstract void Reward(object sender, T reward);
    }
}