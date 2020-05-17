using System;

namespace OregoFramework.Domain
{
    public abstract class OregoBaseGameLauncherInteractor : OregoInteractor, 
        IOregoGameLauncherInteractor
    {
        #region Event

        public event Action<object> OnGameLaunchedEvent;

        #endregion

        public abstract void LaunchGame(object sender);
    }
}