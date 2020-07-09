using System;
using System.Collections.Generic;
using OregoFramework.Core;
using OregoFramework.Tool;
using OregoFramework.Util;
using UnityEngine;

namespace OregoFramework.UI
{
    public abstract class UIScreenController : UIElement, IUIController
    {
        #region Event

        public AutoEvent<UIScreen> OnScreenChangedEvent { get; }

        #endregion

        protected readonly Dictionary<Type, IResource> screenTypeVsResourceMap;

        protected UIScreenController()
        {
            this.OnScreenChangedEvent = this.New<AutoEvent<UIScreen>>();
            this.screenTypeVsResourceMap = new Dictionary<Type, IResource>();
        }

        public UIScreen currentScreen { get; private set; }

        public virtual Transform rootTransform
        {
            get { return this.transform; }
        }

        #region Initialize

        public void Initialize()
        {
            this.LoadScreenResources();
            var defaultScreenType = this.GetDefaultScreenType();
            this.OnInitialize();
            this.StartScreen(defaultScreenType);
        }

        private void LoadScreenResources()
        {
            var resources = this.FetchResources();
            foreach (var resource in resources)
            {
                var screenType = resource.screenType;
                this.screenTypeVsResourceMap[screenType] = resource;
            }
        }

        protected virtual IEnumerable<IUIScreenResource> FetchResources()
        {
            if (!Orego.HasObject(nameof(Resourcer)))
            {
                throw new Exception(Resourcer.EXCEPTION_MESSAGE);
            }

            return Resourcer.GetResources<IUIScreenResource>();
        }

        protected abstract Type GetDefaultScreenType();

        protected virtual void OnInitialize()
        {
        }

        #endregion

        #region Transitions

        public void StartScreen<T>(Action<T> callback = null) where T : UIScreen
        {
            this.StartScreen(typeof(T), window => callback?.Invoke((T) window));
        }

        public virtual void StartScreen(Type screenType, Action<UIScreen> callback = null)
        {
            var previousScreen = this.currentScreen;
            if (previousScreen != null)
            {
                this.currentScreen = null;
                this.UnloadScreen(previousScreen);
            }

            var nextScreen = this.LoadScreen(screenType);
            this.currentScreen = nextScreen;
            this.OnScreenChangedEvent?.Invoke(this.currentScreen);
            callback?.Invoke(nextScreen);
        }

        protected virtual UIScreen LoadScreen(Type screenType)
        {
            var resource = this.screenTypeVsResourceMap.Find(screenType);
            var prefab = Resourcer.Load<UIScreen>(resource);
            var nextScreen = Instantiate(prefab, this.rootTransform);
            return nextScreen;
        }

        protected virtual void UnloadScreen(UIScreen screen)
        {
            Destroy(screen.gameObject);
        }

        #endregion
    }
}