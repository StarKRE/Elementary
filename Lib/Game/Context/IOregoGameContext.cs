using OregoFramework.Util;

namespace OregoFramework.Game
{
    public interface IOregoGameContext
    {
        #region Event

        AutoEvent<object> OnGameLoadedEvent { get; }

        AutoEvent<object> OnGamePreparedEvent { get; }

        AutoEvent<object> OnGameReadyEvent { get; }

        AutoEvent<object> OnGameStartedEvent { get; }

        AutoEvent<object> OnGamePausedEvent { get; }

        AutoEvent<object> OnGameResumedEvent { get; }

        AutoEvent<object> OnGameFinishedEvent { get; }

        #endregion

        OregoGameStatus gameStatus { get; }

        #region Lifecycle

        void LoadGame(object sender);
        
        /// <summary>
        /// <para>Use this method to and bind game components to each other</para>
        /// </summary>
        /// <param name="sender"></param>
        void PrepareGame(object sender);

        ///     <para>Use this method to subscribe game session components on game events.</para>
        void ReadyGame(object sender);

        void StartGame(object sender);

        void PauseGame(object sender);

        void ResumeGame(object sender);

        void FinishGame(object sender);

        void DestroyGame(object sender);

        #endregion
    }

    public enum OregoGameStatus
    {
        CREATING = 0,
        LOADING = 1,
        PREPARING = 2,
        READY = 3,
        PLAYING = 4,
        PAUSING = 5,
        FINISHING = 6,
        DESTROYING = 7
    }
}