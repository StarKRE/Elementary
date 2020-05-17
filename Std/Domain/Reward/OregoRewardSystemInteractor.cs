using System;
using System.Collections.Generic;
using System.Linq;
using OregoFramework.Util;

namespace OregoFramework.Domain
{
    public abstract class OregoRewardSystemInteractor : OregoInteractor, IRewardSystem
    {
        private readonly Dictionary<Type, IRewarder> rewarderMap;

        protected OregoRewardSystemInteractor()
        {
            this.rewarderMap = new Dictionary<Type, IRewarder>();
        }

        #region OnCreate

        public override void OnCreate()
        {
            base.OnCreate();
            var rewarders = this.LoadRewarders();
            foreach (var rewarder in rewarders)
            {
                this.rewarderMap.AddByType(rewarder);
            }
        }

        protected abstract IEnumerable<IRewarder> LoadRewarders();

        #endregion

        public IEnumerable<T> GetRewarders<T>() where T : IRewarder
        {
            return this.rewarderMap.FindAll<T, IRewarder>();
        }

        public T GetRewarder<T>() where T : IRewarder
        {
            return this.rewarderMap.Find<T, IRewarder>();
        }
    }
}