using OregoFramework.Util;

namespace OregoFramework.Game
{
    public abstract class OregoUIGameNode : AutoMonoBehaviour, IOregoUIGameNode
    {
        private IOregoUIGameSession uiGameSession;

        protected T GetUIGameSession<T>() where T : IOregoUIGameSession
        {
            return (T) this.uiGameSession;
        }

        protected T GetGameSession<T>() where T : IOregoGameSession
        {
            return this.uiGameSession.GetGameSession<T>();
        }

        #region Lifecycle

        public virtual void OnAttachGame(IOregoUIGameSession uiGameSession)
        {
            this.uiGameSession = uiGameSession;
        }

        public virtual void OnGamePrepared(object sender)
        {
        }

        public virtual void OnGameReady(object sender)
        {
        }

        public virtual void OnGameStarted(object sender)
        {
        }

        public virtual void OnGamePaused(object sender)
        {
        }

        public virtual void OnGameResumed(object sender)
        {
        }

        public virtual void OnGameFinished(object sender)
        {
        }

        public virtual void OnDetachGame()
        {
        }

        #endregion
    }
}