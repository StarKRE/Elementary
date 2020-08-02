namespace ElementaryFramework.Game
{
    public interface IGameInterface
    {
        void BindGameContext(IGameContext gameContext);

        void UnbindGameContext();

        T GetGameContext<T>() where T : IGameContext;
    }
}