using OregoFramework.Util;

namespace OregoFramework.Game
{
    public abstract class GameNode : AutoMonoBehaviour, IGameNode
    {
        private IGameContext gameContext;

        public virtual void OnAttachGame(IGameContext gameContext)
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

        public virtual void OnDestroyGame(object sender)
        {
            Destroy(this.gameObject);
        }

        public virtual void OnDetachGame()
        {
        }
        
        protected T GetContext<T>() where T : IGameContext
        {
            return (T) this.gameContext;
        }
    }
}