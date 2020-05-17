using System.Collections;
using System.Collections.Generic;
using OregoFramework.Tool;
using OregoFramework.Util;
using UnityEngine;

namespace OregoFramework.Game
{
    using GameNodes = IEnumerable<IOregoGameNode>;
    
    public abstract class OregoSuspendLoadGameSession : OregoNodeGameSession
    {
        private readonly Routine loadGameNodesRoutine;

        protected OregoSuspendLoadGameSession()
        {
            this.loadGameNodesRoutine = RoutineFactory.CreateInstance();
        }
        
        public sealed override void LoadGame(object sender)
        {
            base.LoadGame(sender);
            this.loadGameNodesRoutine.Start(this.LoadGameNodesRoutine(sender));
        }

        private IEnumerator LoadGameNodesRoutine(object sender)
        {
            var result = new Reference<GameNodes>();
            yield return Continuation<GameNodes>.Suspend(result, this.LoadGameNodesSuspend);
            var gameNodes = result.value;
            foreach (var gameNode in gameNodes)
            {
                this.AddNode(gameNode);
            }

            this.OnGameLoadedEvent?.Invoke(sender);
        }

        protected abstract void LoadGameNodesSuspend(Continuation<GameNodes> continuation);
    }
}