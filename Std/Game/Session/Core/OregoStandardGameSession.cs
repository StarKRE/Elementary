using System.Collections;
using System.Collections.Generic;
using OregoFramework.Tool;
using OregoFramework.Util;

namespace OregoFramework.Game
{
    using GameNodes = IEnumerable<IOregoGameNode>;

    public abstract class OregoStandardGameSession : OregoSuspendLoadGameSession
    {
        #region Event

        public sealed override AutoEvent<object> OnGameLoadedEvent { get; }

        public sealed override AutoEvent<object> OnGamePreparedEvent { get; }

        public sealed override AutoEvent<object> OnGameReadyEvent { get; }

        public sealed override AutoEvent<object> OnGameStartedEvent { get; }

        public sealed override AutoEvent<object> OnGamePausedEvent { get; }

        public sealed override AutoEvent<object> OnGameResumedEvent { get; }

        public sealed override AutoEvent<object> OnGameFinishedEvent { get; }

        #endregion

        private readonly Routine loadGameNodesRoutine;

        protected OregoStandardGameSession()
        {
            this.OnGameLoadedEvent = new AutoEvent<object>();
            this.OnGamePreparedEvent = new AutoEvent<object>();
            this.OnGameReadyEvent = new AutoEvent<object>();
            this.OnGameStartedEvent = new AutoEvent<object>();
            this.OnGamePausedEvent = new AutoEvent<object>();
            this.OnGameResumedEvent = new AutoEvent<object>();
            this.OnGameFinishedEvent = new AutoEvent<object>();
            this.loadGameNodesRoutine = RoutineFactory.CreateInstance();
        }

        #region OnLoad

        protected sealed override void LoadGameNodesSuspend(Continuation<GameNodes> continuation)
        {
            this.loadGameNodesRoutine.Start(this.LoadGameNodesRoutine(continuation));
        }

        private IEnumerator LoadGameNodesRoutine(Continuation<GameNodes> continuation)
        {
            var gameNodes = new List<IOregoGameNode>();
            yield return this.OnLoadGameNodesAsync(gameNodes);
            continuation.Continue(gameNodes);
        }

        protected abstract IEnumerator OnLoadGameNodesAsync(List<IOregoGameNode> gameNodes);

        #endregion

        public sealed override void PrepareGame(object sender)
        {
            base.PrepareGame(sender);
            this.OnGamePreparedEvent?.Invoke(sender);
        }

        public sealed override void ReadyGame(object sender)
        {
            base.ReadyGame(sender);
            this.OnGameReadyEvent?.Invoke(sender);
        }

        public sealed override void StartGame(object sender)
        {
            base.StartGame(sender);
            this.OnGameStartedEvent?.Invoke(sender);
        }

        public sealed override void PauseGame(object sender)
        {
            base.PauseGame(sender);
            this.OnGamePausedEvent?.Invoke(sender);
        }

        public sealed override void ResumeGame(object sender)
        {
            base.ResumeGame(sender);
            this.OnGameResumedEvent?.Invoke(sender);
        }

        public sealed override void FinishGame(object sender)
        {
            base.FinishGame(sender);
            this.OnGameFinishedEvent?.Invoke(sender);
        }

        public sealed override void DestroyGame(object sender)
        {
            base.DestroyGame(sender);
            this.OnGameLoadedEvent.Dispose();
            this.OnGamePreparedEvent.Dispose();
            this.OnGameReadyEvent.Dispose();
            this.OnGameStartedEvent.Dispose();
            this.OnGamePausedEvent.Dispose();
            this.OnGameResumedEvent.Dispose();
            this.OnGameFinishedEvent.Dispose();
        }
    }
}