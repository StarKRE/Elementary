using System;
using System.Collections;
using OregoFramework.Util;

namespace OregoFramework.Game
{
    public interface IOregoAsyncLevelBuilder<in TParams, TLevel>
        where TParams : OregoLevelParams
        where TLevel : IOregoLevel
    {
        event Action<TLevel> OnLevelCreatedEvent;

        IEnumerator Build(TParams levelParams, Reference<TLevel> levelResult);
    }
}