namespace OregoFramework.Game
{
    public interface IGameNode
    {
        void OnAttachGame(IGameContext gameContext);
        
        void OnPrepareGame(object sender);

        void OnReadyGame(object sender);

        void OnStartGame(object sender);

        void OnPauseGame(object sender);

        void OnResumeGame(object sender);

        void OnFinishGame(object sender);

        void OnDestroyGame(object sender);

        void OnDetachGame();
    }
}