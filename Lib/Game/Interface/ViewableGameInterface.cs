using System;
using System.Collections.Generic;
using OregoFramework.Util;

namespace OregoFramework.Game
{
    public abstract class ViewableGameInterface : GameInterface
    {
        protected IEnumerable<IGameView> views
        {
            get { return this.viewMap.Values; }
        }

        private readonly Dictionary<Type, IGameView> viewMap;

        protected ViewableGameInterface()
        {
            this.viewMap = new Dictionary<Type, IGameView>();
        }

        public virtual void AddView(IGameView node)
        {
            this.viewMap.AddByType(node);
            node.OnAttachGame(this);
        }

        public virtual void RemoveView(IGameView node)
        {
            node.OnDetachGame();
            this.viewMap.RemoveByType(node);
        }

        public T GetView<T>() where T : IGameView
        {
            return this.viewMap.Find<T, IGameView>();
        }

        public IEnumerable<T> GetViews<T>() where T : IGameView
        {
            return this.viewMap.FindAll<T, IGameView>();
        }
        
        protected override void OnGamePrepared(object sender)
        {
            base.OnGamePrepared(sender);
            foreach (var view in this.views)
            {
                view.OnGamePrepared(sender);
            }
        }

        protected override void OnGameReady(object sender)
        {
            base.OnGameReady(sender);
            foreach (var view in this.views)
            {
                view.OnGameReady(sender);
            }
        }

        protected override void OnGameStarted(object sender)
        {
            base.OnGameStarted(sender);
            foreach (var view in this.views)
            {
                view.OnGameStarted(sender);
            }
        }

        protected override void OnGamePaused(object sender)
        {
            base.OnGamePaused(sender);
            foreach (var view in this.views)
            {
                view.OnGamePaused(sender);
            }
        }

        protected override void OnGameResumed(object sender)
        {
            base.OnGameResumed(sender);
            foreach (var view in this.views)
            {
                view.OnGameResumed(sender);
            }
        }

        protected override void OnGameFinished(object sender)
        {
            base.OnGameFinished(sender);
            foreach (var view in this.views)
            {
                view.OnGameFinished(sender);
            }
        }
    }
}