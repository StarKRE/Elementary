using System;

namespace OregoFramework.Game
{
    /// <summary>
    ///     <para>Base interface of game session maintainer.</para>
    /// </summary>
    public interface IOregoGameSessionController
    {
        #region Event

        /// <summary>
        ///     <para>Invokes when game session is created.</para>
        /// </summary>
        event Action<object, IOregoGameSession> OnGameSessionCreatedEvent;

        /// <summary>
        ///     <para>Invokes when game session is loaded.</para>
        /// </summary>
        event Action<object, IOregoGameSession> OnGameSessionLoadedEvent;

        /// <summary>
        ///     <para>Invokes when game session is prepared.</para>
        /// </summary>
        event Action<object, IOregoGameSession> OnGameSessionPreparedEvent;

        /// <summary>
        ///     <para>Invokes when game session is ready.</para>
        /// </summary>
        event Action<object, IOregoGameSession> OnGameSessionReadyEvent;

        /// <summary>
        ///     <para>Invokes when game session is started.</para>
        /// </summary>
        event Action<object, IOregoGameSession> OnGameSessionStartedEvent;

        /// <summary>
        ///     <para>Invokes when game session is paused.</para>
        /// </summary>
        event Action<object, IOregoGameSession> OnGameSessionPausedEvent;

        /// <summary>
        ///     <para>Invokes when game session is resumed</para>
        /// </summary>
        event Action<object, IOregoGameSession> OnGameSessionResumedEvent;

        /// <summary>
        ///     <para>Invokes when game session is finihsed.</para>
        /// </summary>
        event Action<object, IOregoGameSession> OnGameSessionFinishedEvent;
        
        /// <summary>
        ///     <para>Invokes when game session is destroyed</para>
        /// </summary>
        event Action<object, IOregoGameSession> OnGameSessionDestroyedEvent;

        #endregion

        /// <summary>
        ///     <para>Gets game session of required type.</para>
        /// </summary>
        /// <typeparam name="T">Required type.</typeparam>
        /// <returns>Game session reference.</returns>
        T GetGameSession<T>() where T : IOregoGameSession;

        /// <summary>
        ///     <para>Creates a new game session.</para>
        ///     <para>Use this method to create instance of game session.</para>
        ///     <para>Use the event <see cref="OnGameSessionCreatedEvent"/> to notify about a game session is created.</para>
        /// </summary>
        /// <param name="sender">Invoker object.</param>
        void CreateGameSession(object sender);

        /// <summary>
        ///     <para>Loads inner resources and assets for a game session.</para>
        ///     <para>Use this method to load a game session structure.</para>
        ///     <para>Use the event <see cref="OnGameSessionLoadedEvent"/> to notify about a game session is loaded.</para>
        /// </summary>
        /// <param name="sender">Invoker object.</param>
        void LoadGameSession(object sender);

        /// <summary>
        ///     <para>Prepares game session components for work.</para>
        ///     <para>Use this method to init a game session structure.</para>
        ///     <para>Use the event <see cref="OnGameSessionPreparedEvent"/> to notify about a game session is prepared.</para>
        /// </summary>
        /// <param name="sender">Invoker object.</param>
        void PrepareGameSession(object sender);

        /// <summary>
        ///     <para>Readies game session components to start game.</para>
        ///     <para>Use this method to subscribe game session structure on game events.</para>
        ///     <para>Use the event <see cref="OnGameSessionReadyEvent"/> to notify about a game session is ready for play.</para>
        /// </summary>
        /// <param name="sender">Invoker object.</param>
        void ReadyGameSession(object sender);

        /// <summary>
        ///     <para>Launches a game session for play.</para>
        ///     <para>Use this method start a game session structure for play.</para>
        ///     <para>Use the event <see cref="OnGameSessionStartedEvent"/> to notify about a game session is launched for play.</para>
        /// </summary>
        /// <param name="sender">Invoker object.</param>
        void StartGameSession(object sender);

        /// <summary>
        ///     <para>Pauses a game session.</para>
        ///     <para>Use this method to pause a game session.</para>
        ///     <para>Use the event <see cref="OnGameSessionPausedEvent"/> to notify about a game session is paused.</para>
        /// </summary>
        /// <param name="sender">Invoker object.</param>
        void PauseGameSession(object sender);

        /// <summary>
        ///     <para>Resumes a game session.</para>
        ///     <para>Use this method to resume a game session.</para>
        ///     <para>Use the event <see cref="OnGameSessionResumedEvent"/> to notify about a game session is resumed.</para>
        /// </summary>
        /// <param name="sender">Invoker object.</param>
        void ResumeGameSession(object sender);

        /// <summary>
        ///     <para>Finishes a game session.</para>
        ///     <para>Use this method to finish a game session.</para>
        ///     <para>Use the event <see cref="OnGameSessionFinishedEvent"/> to notify about a game session is finished.</para>
        /// </summary>
        /// <param name="sender">Invoker object.</param>
        void FinishGameSession(object sender);

        /// <summary>
        ///     <para>Destroys a game session.</para>
        ///     <para>Use this method to dispose a game session and its resources.</para>
        ///     <para>Use the event <see cref="OnGameSessionDestroyedEvent"/> to notify about a game session is destroyed.</para>
        /// </summary>
        /// <param name="sender">Invoker object.</param>
        void DestroyGameSession(object sender);
    }
}