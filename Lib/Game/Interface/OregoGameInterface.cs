using OregoFramework.Util;

namespace OregoFramework.Game
{
    public abstract class OregoGameInterface : AutoMonoBehaviour, IOregoGameInterface
    {
        private IOregoGameContext gameContext;

        public virtual void BindGameContext(IOregoGameContext gameContext)
        {
            this.gameContext = gameContext;
            this.gameContext.OnGamePreparedEvent.AddListener(this.OnGamePrepared);
            this.gameContext.OnGameReadyEvent.AddListener(this.OnGameReady);
            this.gameContext.OnGameStartedEvent.AddListener(this.OnGameStarted);
            this.gameContext.OnGamePausedEvent.AddListener(this.OnGamePaused);
            this.gameContext.OnGameResumedEvent.AddListener(this.OnGameResumed);
            this.gameContext.OnGameFinishedEvent.AddListener(this.OnGameFinished);
        }

        public virtual void UnbindGameContext()
        {
            this.gameContext.OnGamePreparedEvent.RemoveListener(this.OnGamePrepared);
            this.gameContext.OnGameReadyEvent.RemoveListener(this.OnGameReady);
            this.gameContext.OnGameStartedEvent.RemoveListener(this.OnGameStarted);
            this.gameContext.OnGamePausedEvent.RemoveListener(this.OnGamePaused);
            this.gameContext.OnGameResumedEvent.RemoveListener(this.OnGameResumed);
            this.gameContext.OnGameFinishedEvent.RemoveListener(this.OnGameFinished);
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

        public T GetGameContext<T>() where T : IOregoGameContext
        {
            return (T) this.gameContext;
        }
    }
}