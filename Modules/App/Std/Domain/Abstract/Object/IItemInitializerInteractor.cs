using System;

namespace ElementaryFramework.App
{
    public interface IItemInitializerInteractor
    {
        event Action<object> OnInitializedEvent;
    }
}