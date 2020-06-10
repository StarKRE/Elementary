using System;
using System.Collections.Generic;
using OregoFramework.Core;
using OregoFramework.Util;

namespace OregoFramework.UI
{
    public abstract class OregoUISystem : OregoUIBehaviour, IOregoUISystem
    {
        private OregoUISystem instance;

        private readonly Dictionary<Type, IOregoUIController> uiControllerMap;

        protected OregoUISystem()
        {
            this.uiControllerMap = new Dictionary<Type, IOregoUIController>();
        }

        protected virtual void Awake()
        {
            ((ISingleton) this).OnBecameSingleton();
        }

        void ISingleton.OnBecameSingleton()
        {
            Orego.AddObject(nameof(IOregoUISystem), this);
        }
        
        public void AddUIController(IOregoUIController uiController)
        {
            this.uiControllerMap.Add(uiController.GetType(), uiController);
        }

        public void RemoveUIController(IOregoUIController uiController)
        {
            this.uiControllerMap.Remove(uiController.GetType());
        }

        public T GetUIController<T>() where T : IOregoUIController
        {
            return this.uiControllerMap.Find<T, IOregoUIController>();
        }

        public IEnumerable<T> GetUIControllers<T>() where T : IOregoUIController
        {
            return this.uiControllerMap.FindAll<T, IOregoUIController>();
        }
    }
}