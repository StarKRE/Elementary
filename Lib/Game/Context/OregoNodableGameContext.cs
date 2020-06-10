using System;
using System.Collections.Generic;
using System.Linq;
using OregoFramework.Util;

namespace OregoFramework.Game
{
    public abstract class OregoNodableGameContext : OregoGameContext
    {
        protected IEnumerable<IOregoGameNode> nodes
        {
            get { return this.nodeMap.Values.ToList(); }
        }

        private readonly Dictionary<Type, IOregoGameNode> nodeMap;

        protected OregoNodableGameContext()
        {
            this.nodeMap = new Dictionary<Type, IOregoGameNode>();
        }

        #region Lifecycle

        public override void PrepareGame(object sender)
        {
            base.PrepareGame(sender);
            this.nodes.ForEach(it => it.OnPrepareGame(sender));
        }

        public override void ReadyGame(object sender)
        {
            base.ReadyGame(sender);
            this.nodes.ForEach(it => it.OnReadyGame(sender));
        }

        public override void StartGame(object sender)
        {
            base.StartGame(sender);
            this.nodes.ForEach(it => it.OnStartGame(sender));
        }

        public override void PauseGame(object sender)
        {
            base.PauseGame(sender);
            this.nodes.ForEach(it => it.OnPauseGame(sender));
        }

        public override void ResumeGame(object sender)
        {
            base.ResumeGame(sender);
            this.nodes.ForEach(it => it.OnResumeGame(sender));
        }

        public override void FinishGame(object sender)
        {
            base.FinishGame(sender);
            this.nodes.ForEach(it => it.OnFinishGame(sender));
        }

        public override void DestroyGame(object sender)
        {
            base.DestroyGame(sender);
            this.nodes.ForEach(it => it.OnDestroyGame(sender));
        }

        #endregion

        public virtual void AddNode(IOregoGameNode gameNode)
        {
            this.nodeMap.AddByType(gameNode);
            gameNode.OnAttachGame(this);
        }

        public virtual void RemoveNode(IOregoGameNode gameNode)
        {
            gameNode.OnDetachGame();
            this.nodeMap.RemoveByType(gameNode);
        }

        public T GetNode<T>() where T : IOregoGameNode
        {
            return this.nodeMap.Find<T, IOregoGameNode>();
        }

        public IEnumerable<T> GetNodes<T>() where T : IOregoGameNode
        {
            return this.nodeMap.FindAll<T, IOregoGameNode>();
        }
    }
}