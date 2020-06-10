using OregoFramework.Util;

namespace OregoFramework.Game
{
    public abstract class OregoGameView : AutoMonoBehaviour, IOregoGameView
    {
        private IOregoGameInterface gameInterface;

        protected T GetGameInterface<T>() where T : IOregoGameInterface
        {
            return (T) this.gameInterface;
        }

        protected T GetGameContext<T>() where T : IOregoGameContext
        {
            return this.gameInterface.GetGameContext<T>();
        }

        #region Lifecycle

        public virtual void OnAttachGame(IOregoGameInterface gameInterface)
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