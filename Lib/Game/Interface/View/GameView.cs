using OregoFramework.Util;

namespace OregoFramework.Game
{
    public abstract class GameView : AutoMonoBehaviour, IGameView
    {
        private IGameInterface gameInterface;

        protected T GetGameInterface<T>() where T : IGameInterface
        {
            return (T) this.gameInterface;
        }

        protected T GetGameContext<T>() where T : IGameContext
        {
            return this.gameInterface.GetGameContext<T>();
        }

        #region Lifecycle

        public virtual void OnAttachGame(IGameInterface gameInterface)
        {
            this.gameInterface = gameInterface;
        }

        public virtual void OnGamePrepared(object sender)
        {
        }

        public virtual void OnGameReady(object sender)
        {
        }

        public virtual void OnGameStarted(object sender)
        {
        }

        public virtual void OnGamePaused(object sender)
        {
        }

        public virtual void OnGameResumed(object sender)
        {
        }

        public virtual void OnGameFinished(object sender)
        {
        }

        public virtual void OnDetachGame()
        {
        }

        #endregion
    }
}