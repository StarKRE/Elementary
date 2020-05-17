using OregoFramework.Util;

namespace OregoFramework.Game
{
    public abstract class OregoGameSession : IOregoGameSession
    {
        #region Event

        public abstract AutoEvent<object> OnGameLoadedEvent { get; }

        public abstract AutoEvent<object> OnGamePreparedEvent { get; }

        public abstract AutoEvent<object> OnGameReadyEvent { get; }

        public abstract AutoEvent<object> OnGameStartedEvent { get; }

        public abstract AutoEvent<object> OnGamePausedEvent { get; }

        public abstract AutoEvent<object> OnGameResumedEvent { get; }

        public abstract AutoEvent<object> OnGameFinishedEvent { get; }

        #endregion

        public OregoGameSessionStatus gameStatus { get; protected set; }

        protected OregoGameSession()
        {
            this.gameStatus = OregoGameSessionStatus.CREATING;
        }

        public virtual void LoadGame(object sender)
        {
            this.gameStatus = OregoGameSessionStatus.LOADING;
        }

        public virtual void PrepareGame(object sender)
        {
            this.gameStatus = OregoGameSessionStatus.PREPARING;
        }

        public virtual void ReadyGame(object sender)
        {
            this.gameStatus = OregoGameSessionStatus.READY;
        }

        public virtual void StartGame(object sender)
        {
            this.gameStatus = OregoGameSessionStatus.PLAYING;
        }

        public virtual void PauseGame(object sender)
        {
            this.gameStatus = OregoGameSessionStatus.PAUSING;
        }

        public virtual void ResumeGame(object sender)
        {
            this.gameStatus = OregoGameSessionStatus.PLAYING;
        }

        public virtual void FinishGame(object sender)
        {
            this.gameStatus = OregoGameSessionStatus.FINISHING;
        }

        public virtual void DestroyGame(object sender)
        {
            this.gameStatus = OregoGameSessionStatus.DESTROYING;
        }
    }
}