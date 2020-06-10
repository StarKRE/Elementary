using System;
using System.Collections;
using OregoFramework.Core;

namespace OregoFramework.Tools
{
    public abstract class OregoContent : OregoComponentLayer<IOregoContentSection>,
        IOregoSingletonComponent
    {
        #region Event

        public static event Action OnLoadedEvent;

        #endregion
        
        private static OregoContent instance;

        public void OnBecameSingleton()
        {
            instance = this;
            Orego.AddObject(nameof(OregoContent), this);
        }

        public static IEnumerator LoadResources()
        {
            yield return instance.LoadResourcesInternal();
            OnLoadedEvent?.Invoke();
        }

        protected virtual IEnumerator LoadResourcesInternal()
        {
            foreach (var section in this.allComponents)
            {
                yield return section.LoadResources();
            }
        }

        public static T GetSection<T>() where T : IOregoContentSection
        {
            return instance.GetSectionInternal<T>();
        }

        protected T GetSectionInternal<T>() where T : IOregoContentSection
        {
            return (T) this[typeof(T)];
        }
    }
}