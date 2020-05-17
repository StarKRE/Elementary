using OregoFramework.Util;

namespace OregoFramework.Game
{
    public abstract class OregoUIGameSession : AutoMonoBehaviour, IOregoUIGameSession
    {
        private IOregoGameSession gameSession;

        public virtual void BindGameSession(IOregoGameSession gameSession)
        {
            this.gameSession = gameSession;
            this.gameSession.OnGamePreparedEvent.AddListener(this.OnGamePrepared);
            this.gameSession.OnGameReadyEvent.AddListener(this.OnGameReady);
            this.gameSession.OnGameStartedEvent.AddListener(this.OnGameStarted);
            this.gameSession.OnGamePausedEvent.AddListener(this.OnGamePaused);
            this.gameSession.OnGameResumedEvent.AddListener(this.OnGameResumed);
            this.gameSession.OnGameFinishedEvent.AddListener(this.OnGameFinished);
        }

        public virtual void UnbindGameSession()
        {
            this.gameSession.OnGamePreparedEvent.RemoveListener(this.OnGamePrepared);
            this.gameSession.OnGameReadyEvent.RemoveListener(this.OnGameReady);
            this.gameSession.OnGameStartedEvent.RemoveListener(this.OnGameStarted);
            this.gameSession.OnGamePausedEvent.RemoveListener(this.OnGamePaused);
            this.gameSession.OnGameResumedEvent.RemoveListener(this.OnGameResumed);
            this.gameSession.OnGameFinishedEvent.RemoveListener(this.OnGameFinished);
            this.gameSession = null;
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

        public T GetGameSession<T>() where T : IOregoGameSession
        {
            return (T) this.gameSession;
        }
    }
}