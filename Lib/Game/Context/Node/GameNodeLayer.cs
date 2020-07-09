using System;
using System.Collections.Generic;
using OregoFramework.Util;

namespace OregoFramework.Game
{
    public abstract class GameNodeLayer : GameNode, IGameNodeLayer
    {
        private readonly Dictionary<Type, IGameNode> nodeMap;

        private IEnumerable<IGameNode> nodes
        {
            get { return this.nodeMap.Values; }
        }

        protected GameNodeLayer()
        {
            this.nodeMap = new Dictionary<Type, IGameNode>();
        }

        public virtual T GetNode<T>() where T : IGameNode
        {
            return this.nodeMap.Find<T, IGameNode>();
        }

        public virtual IEnumerable<T> GetNodes<T>() where T : IGameNode
        {
            return this.nodeMap.FindAll<T, IGameNode>();
        }

        public virtual void AddNode(IGameNode gameNode)
        {
            this.nodeMap.AddByType(gameNode);
            gameNode.OnAttachGame(this.GetContext<IGameContext>());
        }

        public virtual void RemoveNode(IGameNode gameNode)
        {
            gameNode.OnDetachGame();
            this.nodeMap.RemoveByType(gameNode);
        }

        public override void OnPrepareGame(object sender)
        {
            base.OnPrepareGame(sender);
            foreach (var node in this.nodes)
            {
                node.OnPrepareGame(sender);
            }
        }

        public override void OnReadyGame(object sender)
        {
            base.OnReadyGame(sender);
            foreach (var node in this.nodes)
            {
                node.OnReadyGame(sender);
            }
        }

        public override void OnStartGame(object sender)
        {
            base.OnStartGame(sender);
            foreach (var node in this.nodes)
            {
                node.OnStartGame(sender);
            }
        }

        public override void OnPauseGame(object sender)
        {
            base.OnPauseGame(sender);
            foreach (var node in this.nodes)
            {
                node.OnPauseGame(sender);
            }
        }

        public override void OnResumeGame(object sender)
        {
            base.OnResumeGame(sender);
            foreach (var node in this.nodes)
            {
                node.OnResumeGame(sender);
            }
        }

        public override void OnFinishGame(object sender)
        {
            base.OnFinishGame(sender);
            foreach (var node in this.nodes)
            {
                node.OnFinishGame(sender);
            }
        }
    }
}