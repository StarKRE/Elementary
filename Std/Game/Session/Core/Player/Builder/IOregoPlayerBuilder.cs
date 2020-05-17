using System;

namespace OregoFramework.Game
{
    public interface IOregoPlayerBuilder<in TParams, out TPlayer>
        where TParams : OregoPlayerParams
        where TPlayer : IOregoPlayer
    {
        event Action<TPlayer> OnPlayerCreatedEvent;

        TPlayer Build(TParams playerParams);
    }
}