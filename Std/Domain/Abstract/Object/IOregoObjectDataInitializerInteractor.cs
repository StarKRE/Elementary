using System;

namespace OregoFramework.Domain
{
    public interface IOregoObjectDataInitializerInteractor
    {
        event Action<object> OnObjectDataInitializedEvent;
    }
}