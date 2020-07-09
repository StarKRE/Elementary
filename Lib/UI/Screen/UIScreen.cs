using System;
using OregoFramework.Util;

namespace OregoFramework.UI
{
    public abstract class UIScreen : UIElement
    {
        private UIScreenController parent;

        protected virtual void Awake()
        {
            this.parent = this.GetComponentInParent<UIScreenController>();
        }

        protected void StartScreen<T>(Action<T> callback = null) where T : UIScreen
        {
            this.parent.StartScreen(callback);
        }

        protected void StartScreen(Type type, Action<UIScreen> callback = null)
        {
            this.parent.StartScreen(type, callback);
        }
        
        protected T GetParent<T>() where T : UIScreenController
        {
            return (T) this.parent;
        }
    }
}