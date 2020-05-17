using System.Collections.Generic;
using OregoFramework.Util;

namespace OregoFramework.UI
{
    public interface IOregoUISystem : ISingleton
    {
        void AddUIController(IOregoUIController uiController);

        void RemoveUIController(IOregoUIController uiController);

        T GetUIController<T>() where T : IOregoUIController;

        IEnumerable<T> GetUIControllers<T>() where T : IOregoUIController;
    }
}