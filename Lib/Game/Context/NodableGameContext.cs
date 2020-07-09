using System;
using System.Collections.Generic;
using OregoFramework.Util;

namespace OregoFramework.Game
{
    public abstract class NodableGameContext : GameContext
    {
        protected IEnumerable<IGameNode> nodes
        {
            get { return this.nodeMap.Values; }
        }

        private readonly Dictionary<Type, IGameNode> nodeMap;

        protected NodableGameContext()
        {
            this.nodeMap = new Dictionary<Type, IGameNode>();
        }

        #region Lifecycle

        public override void PrepareGame(object sender)
        {
            base.PrepareGame(sender);
            foreach (var node in this.nodes)
            {
                node.OnPrepareGame(sender);
            }
        }

        public override void ReadyGame(object sender)
        {
            base.ReadyGame(sender);
            foreach (var node in this.nodes)
            {
                node.OnReadyGame(sender);
            }
        }

        public override void StartGame(object sender)
        {
            base.StartGame(sender);
            foreach (var node in this.nodes)
            {
                node.OnStartGame(sender);
            }
        }

        public override void PauseGame(object sender)
        {
            base.PauseGame(sender);
            foreach (var node in this.nodes)
            {
                node.OnPauseGame(sender);
            }
        }

        public override void ResumeGame(object sender)
        {
            base.ResumeGame(sender);
            foreach (var node in this.nodes)
            {
                node.OnResumeGame(sender);
            }
        }

        public override void FinishGame(object sender)
        {
            base.FinishGame(sender);
            foreach (var node in this.nodes)
            {
                node.OnFinishGame(sender);
            }
        }

        public override void DestroyGame(object sender)
        {
            base.DestroyGame(sender);
            foreach (var node in this.nodes)
            {
                node.OnDestroyGame(sender);
            }
        }

        #endregion

        public virtual void AddNode(IGameNode gameNode)
        {
            this.nodeMap.AddByType(gameNode);
            gameNode.OnAttachGame(this);
        }

        public virtual void RemoveNode(IGameNode gameNode)
        {
            gameNode.OnDetachGame();
            this.nodeMap.RemoveByType(gameNode);
        }

        public T GetNode<T>() where T : IGameNode
        {
            return this.nodeMap.Find<T, IGameNode>();
        }

        public IEnumerable<T> GetNodes<T>() where T : IGameNode
        {
            return this.nodeMap.FindAll<T, IGameNode>();
        }
    }
}