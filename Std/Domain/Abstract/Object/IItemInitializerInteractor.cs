using System;

namespace OregoFramework.Domain
{
    public interface IItemInitializerInteractor
    {
        event Action<object> OnInitializedEvent;
    }
}