using System;
using OregoFramework.Core;
using OregoFramework.Game;
using OregoFramework.Tool;
using UnityEngine;

namespace OregoFramework.Domain
{
    public abstract class OregoGameSessionStandardInteractor<T> : OregoGameSessionInteractor
        where T : IOregoGameSession
    {
        #region Const

        protected const float PLAY_GAME_TIME_SCALE = 1.0f;

        protected const float PAUSE_TIME_SCALE = 0.0f;

        #endregion

        public abstract IOregoGameSessionBuilder<T> sessionBuilder { get; set; }

        public OregoTimeScaleNode playTimeScaleNode { get; set; }

        public OregoTimeScaleNode pauseTimeScaleNode { get; set; }
        
        protected OregoGameSessionStandardInteractor()
        {
            this.playTimeScaleNode = new OregoTimeScaleNode(PLAY_GAME_TIME_SCALE);
            this.pauseTimeScaleNode = new OregoTimeScaleNode(PAUSE_TIME_SCALE);
        }

        #region OnPrepare

        public override void OnPrepare()
        {
            base.OnPrepare();
            if (!Orego.HasObject("OregoTimeScaleStack"))
            {
                throw new Exception(OregoTimeScaleStack.EXCEPTION_MESSAGE);
            }
        }

        #endregion

        #region CreateGame

        public override void CreateGameSession(object sender)
        {
            this.CheckSessionForNotNull(this.currentGameSession);
            this.currentGameSession = this.sessionBuilder.Build();
            this.SubscribeOnGameSession();
            OregoTimeScaleStack.PushScale(this.playTimeScaleNode);
            this.InvokeOnGameCreatedEvent(sender);
        }

        protected virtual void SubscribeOnGameSession()
        {
            this.currentGameSession.OnGameLoadedEvent.AddListener(this.InvokeOnGameLoadedEvent);
            this.currentGameSession.OnGamePreparedEvent.AddListener(this.InvokeOnGamePreparedEvent);
            this.currentGameSession.OnGameReadyEvent.AddListener(this.InvokeOnGameReadyEvent);
            this.currentGameSession.OnGameStartedEvent.AddListener(this.InvokeOnGameStartedEvent);
            this.currentGameSession.OnGamePausedEvent.AddListener(this.InvokeOnGamePausedEvent);
            this.currentGameSession.OnGameResumedEvent.AddListener(this.InvokeOnGameResumedEvent);
            this.currentGameSession.OnGameFinishedEvent.AddListener(this.InvokeOnGameFinishedEvent);
        }

        #endregion

        #region LoadGame

        public override void LoadGameSession(object sender)
        {
            this.CheckSessionForNull(this.currentGameSession);
            this.currentGameSession.LoadGame(sender);
        }

        #endregion

        #region PrepareGame

        public override void PrepareGameSession(object sender)
        {
            this.CheckSessionForNull(this.currentGameSession);
            this.currentGameSession.PrepareGame(sender);
        }

        #endregion

        #region ReadyGame

        public override void ReadyGameSession(object sender)
        {
            this.CheckSessionForNull(this.currentGameSession);
            this.currentGameSession.ReadyGame(sender);
        }

        #endregion

        #region StartGame

        public override void StartGameSession(object sender)
        {
            this.CheckSessionForNull(this.currentGameSession);
            this.currentGameSession.StartGame(sender);
        }

        #endregion

        #region PauseGame

        public override void PauseGameSession(object sender)
        {
            this.CheckSessionForNull(this.currentGameSession);
            this.CheckSessionForPause(this.currentGameSession);
            OregoTimeScaleStack.PushScale(this.pauseTimeScaleNode);
            this.currentGameSession.PauseGame(sender);
        }

        #endregion

        #region ResumeGame

        public override void ResumeGameSession(object sender)
        {
            this.CheckSessionForNull(this.currentGameSession);
            this.CheckSessionForNotPause(this.currentGameSession);
            OregoTimeScaleStack.PopScale(this.pauseTimeScaleNode);
            this.currentGameSession.ResumeGame(sender);
        }

        #endregion

        #region FinishGame

        public override void FinishGameSession(object sender)
        {
            this.CheckSessionForNull(this.currentGameSession);
            this.currentGameSession.FinishGame(sender);
        }

        public override void DestroyGameSession(object sender)
        {
            OregoTimeScaleStack.PopScale(this.playTimeScaleNode);
            this.UnsubscribeOnGameSession();
            var gameSession = this.currentGameSession;
            this.currentGameSession = null;
            gameSession.DestroyGame(sender);
            Resources.UnloadUnusedAssets();
            this.InvokeOnGameDestroyedEvent(sender, gameSession);
        }

        protected virtual void UnsubscribeOnGameSession()
        {
            this.currentGameSession.OnGameLoadedEvent.RemoveListener(
                this.InvokeOnGameLoadedEvent
            );
            this.currentGameSession.OnGamePreparedEvent.RemoveListener(
                this.InvokeOnGamePreparedEvent
            );
            this.currentGameSession.OnGameReadyEvent.RemoveListener(
                this.InvokeOnGameReadyEvent
            );
            this.currentGameSession.OnGameStartedEvent.RemoveListener(
                this.InvokeOnGameStartedEvent
            );
            this.currentGameSession.OnGamePausedEvent.RemoveListener(
                this.InvokeOnGamePausedEvent
            );
            this.currentGameSession.OnGameFinishedEvent.RemoveListener(
                this.InvokeOnGameFinishedEvent
            );
        }

        #endregion
    }
}