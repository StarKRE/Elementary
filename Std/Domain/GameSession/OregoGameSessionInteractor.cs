using System;
using OregoFramework.Game;

namespace OregoFramework.Domain
{
    /**
     * Managers a game session.
     * Required OregoTimeScaleStack implementation.
     */
    public abstract class OregoGameSessionInteractor : OregoInteractor, IOregoGameSessionController
    {
        #region Event

        public event Action<object, IOregoGameSession> OnGameSessionCreatedEvent;

        public event Action<object, IOregoGameSession> OnGameSessionLoadedEvent;

        public event Action<object, IOregoGameSession> OnGameSessionPreparedEvent;

        public event Action<object, IOregoGameSession> OnGameSessionReadyEvent;

        public event Action<object, IOregoGameSession> OnGameSessionStartedEvent;

        public event Action<object, IOregoGameSession> OnGameSessionPausedEvent;

        public event Action<object, IOregoGameSession> OnGameSessionResumedEvent;

        public event Action<object, IOregoGameSession> OnGameSessionFinishedEvent;
        
        public event Action<object, IOregoGameSession> OnGameSessionDestroyedEvent;

        #endregion

        protected IOregoGameSession currentGameSession { get; set; }

        public T GetGameSession<T>() where T : IOregoGameSession
        {
            return (T) this.currentGameSession;
        }

        public abstract void CreateGameSession(object sender);

        public abstract void LoadGameSession(object sender);

        public abstract void PrepareGameSession(object sender);

        public abstract void ReadyGameSession(object sender);

        public abstract void StartGameSession(object sender);

        public abstract void PauseGameSession(object sender);

        public abstract void ResumeGameSession(object sender);

        public abstract void FinishGameSession(object sender);

        public abstract void DestroyGameSession(object sender);

        #region InvokeEvents

        protected void InvokeOnGameCreatedEvent(object sender)
        {
            this.OnGameSessionCreatedEvent?.Invoke(sender, this.currentGameSession);
        }

        protected void InvokeOnGameLoadedEvent(object sender)
        {
            this.OnGameSessionLoadedEvent?.Invoke(sender, this.currentGameSession);
        }

        protected void InvokeOnGamePreparedEvent(object sender)
        {
            this.OnGameSessionPreparedEvent?.Invoke(sender, this.currentGameSession);
        }

        protected void InvokeOnGameReadyEvent(object sender)
        {
            this.OnGameSessionReadyEvent?.Invoke(sender, this.currentGameSession);
        }

        protected void InvokeOnGameStartedEvent(object sender)
        {
            this.OnGameSessionStartedEvent?.Invoke(sender, this.currentGameSession);
        }

        protected void InvokeOnGamePausedEvent(object sender)
        {
            this.OnGameSessionPausedEvent?.Invoke(sender, this.currentGameSession);
        }

        protected void InvokeOnGameResumedEvent(object sender)
        {
            this.OnGameSessionResumedEvent?.Invoke(sender, this.currentGameSession);
        }

        protected void InvokeOnGameFinishedEvent(object sender)
        {
            this.OnGameSessionFinishedEvent?.Invoke(sender, this.currentGameSession);
        }

        protected void InvokeOnGameDestroyedEvent(object sender, IOregoGameSession destroyedGameSession)
        {
            this.OnGameSessionDestroyedEvent?.Invoke(sender, destroyedGameSession);
        }

        #endregion
    }
}