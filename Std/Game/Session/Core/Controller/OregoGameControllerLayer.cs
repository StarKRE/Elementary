using System;
using System.Collections.Generic;
using OregoFramework.Util;

namespace OregoFramework.Game
{
    public abstract class OregoGameControllerLayer : OregoGameController, IOregoGameNodeLayer
    {
        private readonly Dictionary<Type, IOregoGameNode> gameNodeMap;

        private readonly HashSet<IOregoGameNode> gameNodeSet;

        protected OregoGameControllerLayer()
        {
            this.gameNodeMap = new Dictionary<Type, IOregoGameNode>();
            this.gameNodeSet = new HashSet<IOregoGameNode>();
        }

        public virtual T GetNode<T>() where T : IOregoGameNode
        {
            return this.gameNodeMap.Find<T, IOregoGameNode>();
        }

        public virtual IEnumerable<T> GetNodes<T>() where T : IOregoGameNode
        {
            return this.gameNodeMap.FindAll<T, IOregoGameNode>();
        }

        public virtual void AddNode(IOregoGameNode gameNode)
        {
            this.gameNodeMap.AddByType(gameNode);
            this.gameNodeSet.Add(gameNode);
            gameNode.OnAttachGame(this.GetGameSession<IOregoGameSession>());
        }

        public virtual void RemoveNode(IOregoGameNode gameNode)
        {
            gameNode.OnDetachGame();
            this.gameNodeMap.RemoveByType(gameNode);
            this.gameNodeSet.Remove(gameNode);
        }

        public override void OnPrepareGame(object sender)
        {
            base.OnPrepareGame(sender);
            this.gameNodeSet.ForEach(it => it.OnPrepareGame(sender));
        }

        public override void OnReadyGame(object sender)
        {
            base.OnReadyGame(sender);
            this.gameNodeSet.ForEach(it => it.OnReadyGame(sender));
        }

        public override void OnStartGame(object sender)
        {
            base.OnStartGame(sender);
            this.gameNodeSet.ForEach(it => it.OnStartGame(sender));
        }

        public override void OnPauseGame(object sender)
        {
            base.OnPauseGame(sender);
            this.gameNodeSet.ForEach(it => it.OnPauseGame(sender));
        }

        public override void OnResumeGame(object sender)
        {
            base.OnResumeGame(sender);
            this.gameNodeSet.ForEach(it => it.OnResumeGame(sender));
        }

        public override void OnFinishGame(object sender)
        {
            base.OnFinishGame(sender);
            this.gameNodeSet.ForEach(it => it.OnFinishGame(sender));
        }
    }
}