using System;

namespace OregoFramework.Game
{
    public interface IGameContext
    {
        #region Event

        event Action<object> OnGameLoadedEvent;

        event Action<object> OnGamePreparedEvent;

        event Action<object> OnGameReadyEvent;

        event Action<object> OnGameStartedEvent;

        event Action<object> OnGamePausedEvent;

        event Action<object> OnGameResumedEvent;

        event Action<object> OnGameFinishedEvent;

        #endregion

        GameStatus gameStatus { get; }

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
}