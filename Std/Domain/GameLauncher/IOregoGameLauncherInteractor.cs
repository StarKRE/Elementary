using System;

namespace OregoFramework.Domain
{
    public interface IOregoGameLauncherInteractor : IOregoInteractor
    {
        event Action<object> OnGameLaunchedEvent;

        void LaunchGame(object sender);
    }
}