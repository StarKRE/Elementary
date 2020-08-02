using ElementaryFramework.Util;

namespace ElementaryFramework.Game
{
    public abstract class GameNode : AutoMonoBehaviour, IGameNode
    {
        protected IGameContext gameContext { get; private set; }

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
    }
}