using System;
using OregoFramework.Util;

namespace OregoFramework.UI
{
    public abstract class OregoUIScreen : OregoUIElement
    {
        private OregoUIScreenController parent;

        protected virtual void Awake()
        {
            this.parent = this.GetComponentInParent<OregoUIScreenController>();
        }

        protected void StartScreen<T>(Action<T> callback = null) where T : OregoUIScreen
        {
            this.parent.StartScreen(callback);
        }

        protected void StartScreen(Type type, Action<OregoUIScreen> callback = null)
        {
            this.parent.StartScreen(type, callback);
        }
        
        protected T GetParent<T>() where T : OregoUIScreenController
        {
            return (T) this.parent;
        }
    }
}