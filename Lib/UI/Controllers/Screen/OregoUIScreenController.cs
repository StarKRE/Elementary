using System;
using System.Collections.Generic;
using OregoFramework.Core;
using OregoFramework.Tool;
using OregoFramework.Util;
using UnityEngine;

namespace OregoFramework.UI
{
    public abstract class OregoUIScreenController : OregoUIElement, IOregoUIController
    {
        #region Event

        public AutoEvent<OregoUIScreen> OnScreenChangedEvent { get; }

        #endregion

        protected readonly Dictionary<Type, IOregoResource> screenTypeVsResourceMap;

        protected OregoUIScreenController()
        {
            this.OnScreenChangedEvent = this.New<AutoEvent<OregoUIScreen>>();
            this.screenTypeVsResourceMap = new Dictionary<Type, IOregoResource>();

        }

        public OregoUIScreen currentScreen { get; private set; }

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

        protected virtual IEnumerable<IOregoUIScreenResource> FetchResources()
        {
            if (!Orego.HasObject(nameof(OregoResourcer)))
            {
                throw new Exception(OregoResourcer.EXCEPTION_MESSAGE);
            }

            return OregoResourcer.GetResources<IOregoUIScreenResource>();
        }

        protected abstract Type GetDefaultScreenType();

        protected virtual void OnInitialize()
        {
        }

        #endregion

        #region Transitions

        public void StartScreen<T>(Action<T> callback = null) where T : OregoUIScreen
        {
            this.StartScreen(typeof(T), window => callback?.Invoke((T) window));
        }

        public virtual void StartScreen(Type screenType, Action<OregoUIScreen> callback = null)
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

        protected virtual OregoUIScreen LoadScreen(Type screenType)
        {
            var resource = this.screenTypeVsResourceMap.Find(screenType);
            var prefab = OregoResourcer.Load<OregoUIScreen>(resource);
            var nextScreen = Instantiate(prefab, this.rootTransform);
            return nextScreen;
        }

        protected virtual void UnloadScreen(OregoUIScreen screen)
        {
            Destroy(screen.gameObject);
        }

        #endregion
    }
}