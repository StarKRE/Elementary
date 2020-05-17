using System;
using System.Collections.Generic;
using System.Linq;
using OregoFramework.Util;

namespace OregoFramework.Game
{
    public abstract class OregoUINodeGameSession : OregoUIGameSession
    {
        protected IEnumerable<IOregoUIGameNode> nodes
        {
            get { return this.nodeMap.Values.ToList(); }
        }

        private readonly Dictionary<Type, IOregoUIGameNode> nodeMap;


        protected OregoUINodeGameSession()
        {
            this.nodeMap = new Dictionary<Type, IOregoUIGameNode>();
        }

        public virtual void AddUINode(IOregoUIGameNode node)
        {
            this.nodeMap.AddByType(node);
            node.OnAttachGame(this);
        }

        public virtual void RemoveUINode(IOregoUIGameNode node)
        {
            node.OnDetachGame();
            this.nodeMap.RemoveByType(node);
        }

        public T GetUINode<T>() where T : IOregoUIGameNode
        {
            return this.nodeMap.Find<T, IOregoUIGameNode>();
        }

        public IEnumerable<T> GetUINodes<T>() where T : IOregoUIGameNode
        {
            return this.nodeMap.FindAll<T, IOregoUIGameNode>();
        }
        
        protected override void OnGamePrepared(object sender)
        {
            base.OnGamePrepared(sender);
            this.nodes.ForEach(it => it.OnGamePrepared(sender));
        }

        protected override void OnGameReady(object sender)
        {
            base.OnGameReady(sender);
            this.nodes.ForEach(it => it.OnGameReady(sender));
        }

        protected override void OnGameStarted(object sender)
        {
            base.OnGameStarted(sender);
            this.nodes.ForEach(it => it.OnGameStarted(sender));
        }

        protected override void OnGamePaused(object sender)
        {
            base.OnGamePaused(sender);
            this.nodes.ForEach(it => it.OnGamePaused(sender));
        }

        protected override void OnGameResumed(object sender)
        {
            base.OnGameResumed(sender);
            this.nodes.ForEach(it => it.OnGameResumed(sender));
        }

        protected override void OnGameFinished(object sender)
        {
            base.OnGameFinished(sender);
            this.nodes.ForEach(it => it.OnGameFinished(sender));
        }
    }
}