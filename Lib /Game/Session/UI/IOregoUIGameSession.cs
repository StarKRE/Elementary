namespace OregoFramework.Game
{
    public interface IOregoUIGameSession
    {
        void BindGameSession(IOregoGameSession gameSession);

        void UnbindGameSession();

        T GetGameSession<T>() where T : IOregoGameSession;
    }
}