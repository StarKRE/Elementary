namespace OregoFramework.Game
{
    public interface IOregoGameView
    {
        void OnAttachGame(IOregoGameInterface gameInterface);
        
        void OnGamePrepared(object sender);

        void OnGameReady(object sender);
        
        void OnGameStarted(object sender);

        void OnGamePaused(object sender);

        void OnGameResumed(object sender);

        void OnGameFinished(object sender);

        void OnDetachGame();
    }
}