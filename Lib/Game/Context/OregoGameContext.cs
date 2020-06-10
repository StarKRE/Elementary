using OregoFramework.Util;

namespace OregoFramework.Game
{
    public abstract class OregoGameContext : IOregoGameContext
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

        public OregoGameStatus gameStatus { get; protected set; }

        protected OregoGameContext()
        {
            this.gameStatus = OregoGameStatus.CREATING;
        }

        public virtual void LoadGame(object sender)
        {
            this.gameStatus = OregoGameStatus.LOADING;
        }

        public virtual void PrepareGame(object sender)
        {
            this.gameStatus = OregoGameStatus.PREPARING;
        }

        public virtual void ReadyGame(object sender)
        {
            this.gameStatus = OregoGameStatus.READY;
        }

        public virtual void StartGame(object sender)
        {
            this.gameStatus = OregoGameStatus.PLAYING;
        }

        public virtual void PauseGame(object sender)
        {
            this.gameStatus = OregoGameStatus.PAUSING;
        }

        public virtual void ResumeGame(object sender)
        {
            this.gameStatus = OregoGameStatus.PLAYING;
        }

        public virtual void FinishGame(object sender)
        {
            this.gameStatus = OregoGameStatus.FINISHING;
        }

        public virtual void DestroyGame(object sender)
        {
            this.gameStatus = OregoGameStatus.DESTROYING;
        }
    }
}