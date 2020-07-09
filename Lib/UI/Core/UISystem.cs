using System;
using System.Collections.Generic;
using OregoFramework.Core;
using OregoFramework.Util;

namespace OregoFramework.UI
{
    public abstract class UISystem : UIBehaviour, IUISystem
    {
        private UISystem instance;

        private readonly Dictionary<Type, IUIController> uiControllerMap;

        protected UISystem()
        {
            this.uiControllerMap = new Dictionary<Type, IUIController>();
        }

        protected virtual void Awake()
        {
            ((ISingleton) this).OnBecameSingleton();
        }

        void ISingleton.OnBecameSingleton()
        {
            Orego.AddObject(nameof(IUISystem), this);
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