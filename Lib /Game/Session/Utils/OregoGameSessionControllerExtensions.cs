using System;
using OregoFramework.Game;

namespace OregoFramework.Domain
{
    public static class OregoGameSessionControllerExtensions
    {
        public static T CreateGameSession<T>(
            this IOregoGameSessionController controller,
            object sender
        )
            where T : IOregoGameSession
        {
            controller.CreateGameSession(sender);
            return controller.GetGameSession<T>();
        }

        public static void CheckSessionForNotNull(
            this IOregoGameSessionController controller,
            IOregoGameSession gameSession
        )
        {
            if (gameSession != null)
            {
                throw new Exception("Current session already created!");
            }
        }

        public static void CheckSessionForNull(
            this IOregoGameSessionController controller,
            IOregoGameSession gameSession
        )
        {
            if (gameSession == null)
            {
                throw new Exception("Current session is null!");
            }
        }

        public static void CheckSessionForPause(
            this IOregoGameSessionController controller,
            IOregoGameSession gameSession
        )
        {
            if (gameSession.gameStatus == OregoGameSessionStatus.PAUSING)
            {
                throw new Exception("Current session has already paused!");
            }
        }

        public static void CheckSessionForNotPause(
            this IOregoGameSessionController controller,
            IOregoGameSession gameSession
        )
        {
            if (gameSession.gameStatus != OregoGameSessionStatus.PAUSING)
            {
                throw new Exception("Current session has not paused!");
            }
        }
    }
}