using System;
using System.Collections;
using OregoFramework.Util;

namespace OregoFramework.Game
{
    public interface IOregoAsyncPlayerBuilder<in TParams, TPlayer>
        where TParams : OregoPlayerParams
        where TPlayer : IOregoPlayer
    {
        event Action<TPlayer> OnPlayerCreatedEvent;

        IEnumerator Build(TParams playerParams, Reference<TPlayer> playerResult);
    }
}