namespace OregoFramework.Game
{
    public interface IOregoUIGameNode
    {
        void OnAttachGame(IOregoUIGameSession uiGameSession);
        
        void OnGamePrepared(object sender);

        void OnGameReady(object sender);
        
        void OnGameStarted(object sender);

        void OnGamePaused(object sender);

        void OnGameResumed(object sender);

        void OnGameFinished(object sender);

        void OnDetachGame();
    }
}