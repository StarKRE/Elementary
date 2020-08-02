using System;
using System.Collections.Generic;
using ElementaryFramework.Util;

namespace ElementaryFramework.App
{
    public abstract class UISystem : UIBehaviour, IUISystem
    {
        public static UISystem instance { get; private set; }

        private readonly Dictionary<Type, IUIController> uiControllerMap;

        protected UISystem()
        {
            this.uiControllerMap = new Dictionary<Type, IUIController>();
        }

        protected virtual void Awake()
        {
            instance = this;
        }

        public void AddUIController(IUIController uiController)
        {
            this.uiControllerMap.Add(uiController.GetType(), uiController);
        }

        public void RemoveUIController(IUIController uiController)
        {
            this.uiControllerMap.Remove(uiController.GetType());
        }

        public T GetUIController<T>() where T : IUIController
        {
            return this.uiControllerMap.Find<T, IUIController>();
        }

        public IEnumerable<T> GetUIControllers<T>() where T : IUIController
        {
            return this.uiControllerMap.FindAll<T, IUIController>();
        }
    }
}