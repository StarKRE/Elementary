using System;
using System.Collections;
using OregoFramework.Game;
using OregoFramework.Tool;
using OregoFramework.Util;
using UnityEngine;

namespace OregoFramework.Domain
{
    public abstract class OregoStandardGameLauncherInteractor : OregoBaseGameLauncherInteractor
    {
        private Routine asyncRoutine;
        
        protected IOregoGameSessionController gameSessionController { get; private set; }
        
        public override void OnCreate()
        {
            base.OnCreate();
            this.asyncRoutine = RoutineFactory.CreateInstance();
        }

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.gameSessionController = this.FetchGameSessionController();
        }

        protected virtual IOregoGameSessionController FetchGameSessionController()
        {
            return this.GetInteractor<OregoGameSessionInteractor>();
        }

        public override void OnReady()
        {
            base.OnReady();
            this.gameSessionController.OnGameSessionLoadedEvent += this.OnGameLoaded;
            this.gameSessionController.OnGameSessionPreparedEvent += this.OnGamePrepared;
            this.gameSessionController.OnGameSessionReadyEvent += this.OnGameReady;
        }

        public override void OnStop()
        {
            base.OnStop();
            this.gameSessionController.OnGameSessionLoadedEvent -= this.OnGameLoaded;
            this.gameSessionController.OnGameSessionPreparedEvent -= this.OnGamePrepared;
            this.gameSessionController.OnGameSessionReadyEvent -= this.OnGameReady;
        }

        public override void LaunchGame(object sender)
        {
            this.Async(() => this.gameSessionController.LoadGameSession(sender));
        }

        protected virtual void OnGameLoaded(object sender, IOregoGameSession oregoGameSession)
        {
            this.Async(() => this.gameSessionController.PrepareGameSession(sender));
        }

        protected virtual void OnGamePrepared(object sender, IOregoGameSession oregoGameSession)
        {
            this.Async(() => this.gameSessionController.ReadyGameSession(sender));
        }

        protected virtual void OnGameReady(object sender, IOregoGameSession oregoGameSession)
        {
            this.Async(() => this.gameSessionController.StartGameSession(sender));
        }

        protected void Async(Action action)
        {
            this.asyncRoutine.ForceStart(this.InvokeAfterFrame(action));
        }

        private IEnumerator InvokeAfterFrame(Action action)
        {
            yield return new WaitForEndOfFrame();
            action?.Invoke();
        }
    }
}