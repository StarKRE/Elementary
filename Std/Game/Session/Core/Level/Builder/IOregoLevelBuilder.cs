using System;

namespace OregoFramework.Game
{
    public interface IOregoLevelBuilder<in TParams, out TLevel>
        where TParams : OregoLevelParams
        where TLevel : IOregoLevel
    {
        event Action<TLevel> OnLevelCreatedEvent;

        TLevel Build(TParams levelParams);
    }
}