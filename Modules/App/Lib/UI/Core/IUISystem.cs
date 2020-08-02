using System.Collections.Generic;

namespace ElementaryFramework.App
{
    public interface IUISystem
    {
        void AddUIController(IUIController uiController);

        void RemoveUIController(IUIController uiController);

        T GetUIController<T>() where T : IUIController;

        IEnumerable<T> GetUIControllers<T>() where T : IUIController;
    }
}