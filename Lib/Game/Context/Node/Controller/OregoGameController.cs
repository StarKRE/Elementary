using OregoFramework.Util;

namespace OregoFramework.Game
{
    public abstract class OregoGameController : AutoScriptableObject, IOregoGameNode
    {
        private IOregoGameContext gameContext;

        public virtual void OnAttachGame(IOregoGameContext gameContext)
        {
            this.gameContext = gameContext;
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

        public void OnDestroyGame(object sender)
        {
            Destroy(this);
        }

        public virtual void OnDetachGame()
        {
        }

        protected T GetContext<T>() where T : IOregoGameContext
        {
            return (T) this.gameContext;
        }
    }
}