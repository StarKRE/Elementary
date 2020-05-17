using OregoFramework.Game;

namespace OregoFramework.Domain
{
    public abstract class OregoGameSessionBuilder<T> : OregoDomainComponent,
        IOregoGameSessionBuilder<T>
        where T : OregoGameSession
    {
        public abstract T Build();
    }
}