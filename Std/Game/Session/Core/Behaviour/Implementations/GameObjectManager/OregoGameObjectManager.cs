using System.Collections.Generic;
using System.Linq;
using OregoFramework.Game;

namespace OregoFramework.Util
{
    public abstract class OregoGameObjectManager<T> : OregoAutoGameBehaviour
    {
        protected HashSet<T> gameObjectSet { get; }

        protected OregoGameObjectManager()
        {
            this.gameObjectSet = new HashSet<T>();
        }

        #region OnPrepareGame

        public sealed override void OnPrepareGame(object sender)
        {
            base.OnPrepareGame(sender);
            this.OnPrepareGame(sender, this);
            var gameObjects = this.FetchGameObjects();
            foreach (var other in gameObjects)
            {
                this.OnPrepareGameObject(other);
                this.gameObjectSet.Add(other);
            }
        }

        protected virtual void OnPrepareGame(object sender, OregoGameObjectManager<T> self)
        {
        }

        protected abstract IEnumerable<T> FetchGameObjects();

        protected virtual void OnPrepareGameObject(T other)
        {
        }

        #endregion

        #region OnReadyGame

        public sealed override void OnReadyGame(object sender)
        {
            base.OnReadyGame(sender);
            this.OnReadyGame(sender, this);
            foreach (var other in this.gameObjectSet)
            {
                this.OnReadyGameObject(other);
            }
        }

        protected virtual void OnReadyGameObject(T other)
        {
        }

        protected virtual void OnReadyGame(object sender, OregoGameObjectManager<T> self)
        {
        }

        #endregion

        #region OnStartGame

        public sealed override void OnStartGame(object sender)
        {
            base.OnStartGame(sender);
            this.OnStartGame(sender, this);
            foreach (var other in this.gameObjectSet)
            {
                this.OnStartGameObject(other);
            }
        }

        protected virtual void OnStartGameObject(T other)
        {
        }

        protected virtual void OnStartGame(object sender, OregoGameObjectManager<T> self)
        {
        }

        #endregion

        #region OnPauseGame

        public sealed override void OnPauseGame(object sender)
        {
            base.OnPauseGame(sender);
            this.OnPauseGame(sender, this);
            foreach (var other in this.gameObjectSet)
            {
                this.OnPauseGameObject(other);
            }
        }

        protected virtual void OnPauseGameObject(T other)
        {
        }

        protected virtual void OnPauseGame(object sender, OregoGameObjectManager<T> self)
        {
        }

        #endregion

        #region OnResumeGame

        public sealed override void OnResumeGame(object sender)
        {
            base.OnResumeGame(sender);
            this.OnResumeGame(sender, this);
            foreach (var other in this.gameObjectSet)
            {
                this.OnResumeGameObject(other);
            }
        }

        protected virtual void OnResumeGameObject(T other)
        {
        }

        protected virtual void OnResumeGame(object sender, OregoGameObjectManager<T> self)
        {
        }

        #endregion

        #region OnFinishGame

        public sealed override void OnFinishGame(object sender)
        {
            base.OnFinishGame(sender);
            var gameObjects = this.gameObjectSet.ToList();
            foreach (var other in gameObjects)
            {
                this.OnFinishGameObject(other);
            }
        }

        protected virtual void OnFinishGameObject(T other)
        {
            this.gameObjectSet.Remove(other);
        }

        #endregion

        public IEnumerable<R> GetObjects<R>()
        {
            return this.gameObjectSet.OfType<R>();
        }

        public int GetObjectCount()
        {
            return this.gameObjectSet.Count;
        }
    }
}