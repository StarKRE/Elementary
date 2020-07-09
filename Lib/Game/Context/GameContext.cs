using System;

namespace OregoFramework.Game
{
    public abstract class GameContext : IGameContext
    {
        #region Event

        public abstract event Action<object> OnGameLoadedEvent;

        public abstract event Action<object> OnGamePreparedEvent;

        public abstract event Action<object> OnGameReadyEvent;

        public abstract event Action<object> OnGameStartedEvent;

        public abstract event Action<object> OnGamePausedEvent;

        public abstract event Action<object> OnGameResumedEvent;

        public abstract event Action<object> OnGameFinishedEvent;

        #endregion

        public GameStatus gameStatus { get; protected set; }

        protected GameContext()
        {
            this.gameStatus = GameStatus.CREATING;
        }

        public virtual void LoadGame(object sender)
        {
            this.gameStatus = GameStatus.LOADING;
        }

        public virtual void PrepareGame(object sender)
        {
            this.gameStatus = GameStatus.PREPARING;
        }

        public virtual void ReadyGame(object sender)
        {
            this.gameStatus = GameStatus.READY;
        }

        public virtual void StartGame(object sender)
        {
            this.gameStatus = GameStatus.PLAYING;
        }

        public virtual void PauseGame(object sender)
        {
            this.gameStatus = GameStatus.PAUSING;
        }

        public virtual void ResumeGame(object sender)
        {
            this.gameStatus = GameStatus.PLAYING;
        }

        public virtual void FinishGame(object sender)
        {
            this.gameStatus = GameStatus.FINISHING;
        }

        public virtual void DestroyGame(object sender)
        {
            this.gameStatus = GameStatus.DESTROYING;
        }
    }
}