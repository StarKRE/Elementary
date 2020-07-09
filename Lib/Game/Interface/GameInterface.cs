using OregoFramework.Util;

namespace OregoFramework.Game
{
    public abstract class GameInterface : AutoMonoBehaviour, IGameInterface
    {
        private IGameContext gameContext;

        public virtual void BindGameContext(IGameContext gameContext)
        {
            this.gameContext = gameContext;
            this.gameContext.OnGamePreparedEvent += this.OnGamePrepared;
            this.gameContext.OnGameReadyEvent += this.OnGameReady;
            this.gameContext.OnGameStartedEvent += this.OnGameStarted;
            this.gameContext.OnGamePausedEvent += this.OnGamePaused;
            this.gameContext.OnGameResumedEvent += this.OnGameResumed;
            this.gameContext.OnGameFinishedEvent += this.OnGameFinished;
        }

        public virtual void UnbindGameContext()
        {
            this.gameContext.OnGamePreparedEvent -= this.OnGamePrepared;
            this.gameContext.OnGameReadyEvent -= this.OnGameReady;
            this.gameContext.OnGameStartedEvent -= this.OnGameStarted;
            this.gameContext.OnGamePausedEvent -= this.OnGamePaused;
            this.gameContext.OnGameResumedEvent -= this.OnGameResumed;
            this.gameContext.OnGameFinishedEvent -= this.OnGameFinished;
            this.gameContext = null;
        }

        protected virtual void OnGamePrepared(object sender)
        {
        }

        protected virtual void OnGameReady(object sender)
        {
        }

        protected virtual void OnGameStarted(object sender)
        {
        }

        protected virtual void OnGamePaused(object sender)
        {
        }

        protected virtual void OnGameResumed(object sender)
        {
        }

        protected virtual void OnGameFinished(object sender)
        {
        }

        public T GetGameContext<T>() where T : IGameContext
        {
            return (T) this.gameContext;
        }
    }
}