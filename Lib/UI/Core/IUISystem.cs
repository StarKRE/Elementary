using System.Collections.Generic;
using OregoFramework.Util;

namespace OregoFramework.UI
{
    public interface IUISystem : ISingleton
    {
        void AddUIController(IUIController uiController);

        void RemoveUIController(IUIController uiController);

        T GetUIController<T>() where T : IUIController;

        IEnumerable<T> GetUIControllers<T>() where T : IUIController;
    }
}