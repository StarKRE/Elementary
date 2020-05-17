namespace OregoFramework.Game
{
    /// <summary>
    ///     <para>Interface that builds a game session.</para>
    /// </summary>
    /// <typeparam name="T">Game session type.</typeparam>
    public interface IOregoGameSessionBuilder<out T> where T : IOregoGameSession
    {
        T Build();
    }
}