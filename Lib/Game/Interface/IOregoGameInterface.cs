namespace OregoFramework.Game
{
    public interface IOregoGameInterface
    {
        void BindGameContext(IOregoGameContext gameContext);

        void UnbindGameContext();

        T GetGameContext<T>() where T : IOregoGameContext;
    }
}