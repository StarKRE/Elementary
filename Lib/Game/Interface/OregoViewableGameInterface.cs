using System;
using System.Collections.Generic;
using System.Linq;
using OregoFramework.Util;

namespace OregoFramework.Game
{
    public abstract class OregoViewableGameInterface : OregoGameInterface
    {
        protected IEnumerable<IOregoGameView> views
        {
            get { return this.viewMap.Values.ToList(); }
        }

        private readonly Dictionary<Type, IOregoGameView> viewMap;


        protected OregoViewableGameInterface()
        {
            this.viewMap = new Dictionary<Type, IOregoGameView>();
        }

        public virtual void AddView(IOregoGameView node)
        {
            this.viewMap.AddByType(node);
            node.OnAttachGame(this);
        }

        public virtual void RemoveView(IOregoGameView node)
        {
            node.OnDetachGame();
            this.viewMap.RemoveByType(node);
        }

        public T GetView<T>() where T : IOregoGameView
        {
            return this.viewMap.Find<T, IOregoGameView>();
        }

        public IEnumerable<T> GetViews<T>() where T : IOregoGameView
        {
            return this.viewMap.FindAll<T, IOregoGameView>();
        }
        
        protected override void OnGamePrepared(object sender)
        {
            base.OnGamePrepared(sender);
            this.views.ForEach(it => it.OnGamePrepared(sender));
        }

        protected override void OnGameReady(object sender)
        {
            base.OnGameReady(sender);
            this.views.ForEach(it => it.OnGameReady(sender));
        }

        protected override void OnGameStarted(object sender)
        {
            base.OnGameStarted(sender);
            this.views.ForEach(it => it.OnGameStarted(sender));
        }

        protected override void OnGamePaused(object sender)
        {
            base.OnGamePaused(sender);
            this.views.ForEach(it => it.OnGamePaused(sender));
        }

        protected override void OnGameResumed(object sender)
        {
            base.OnGameResumed(sender);
            this.views.ForEach(it => it.OnGameResumed(sender));
        }

        protected override void OnGameFinished(object sender)
        {
            base.OnGameFinished(sender);
            this.views.ForEach(it => it.OnGameFinished(sender));
        }
    }
}