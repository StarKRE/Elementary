using System;
using System.Collections;
using ElementaryFramework.Core;

namespace ElementaryFramework.Unit
{
    public abstract class Content : ElementLayer<IContentSection>, IRootElement
    {
        #region Event

        public static event Action OnLoadedEvent;

        #endregion

        private static Content instance;

        public override void OnCreate(IElementContext context)
        {
            base.OnCreate(context);
            instance = this;
        }

        public static IEnumerator LoadResources()
        {
            yield return instance.LoadResourcesInternal();
            OnLoadedEvent?.Invoke();
        }

        protected virtual IEnumerator LoadResourcesInternal()
        {
            foreach (var section in this.allElements)
            {
                yield return section.LoadResources();
            }
        }

        public static T GetSection<T>() where T : IContentSection
        {
            return instance.GetSectionInternal<T>();
        }

        protected T GetSectionInternal<T>() where T : IContentSection
        {
            return instance.GetElement<T>();
        }
    }
}