using OregoFramework.Util;

namespace OregoFramework.Game
{
    public abstract class OregoGameBehaviour : AutoMonoBehaviour, IOregoGameNode
    {
        private IOregoGameSession gameSession;

        public virtual void OnAttachGame(IOregoGameSession gameSession)
        {
            this.gameSession = gameSession;
        }

        public virtual void OnPrepareGame(object sender)
        {
        }

        public virtual void OnReadyGame(object sender)
        {
        }

        public virtual void OnStartGame(object sender)
        {
        }

        public virtual void OnPauseGame(object sender)
        {
        }

        public virtual void OnResumeGame(object sender)
        {
        }

        public virtual void OnFinishGame(object sender)
        {
        }

        public virtual void OnDestroyGame(object sender)
        {
            Destroy(this.gameObject);
        }

        public virtual void OnDetachGame()
        {
        }

        #region GameSession

        protected T GetGameSession<T>() where T : IOregoGameSession
        {
            return (T) this.gameSession;
        }

        #endregion
    }
}