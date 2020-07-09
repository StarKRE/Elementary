using System;

namespace OregoFramework.UI
{
    public abstract class UICachedScreen : UIScreen
    {
        protected void StartPreviousScreen(Action<UIScreen> callback = null)
        {
            var parent = this.GetParent<UICachedScreenController>();
            parent.StartPreviousScreen(callback);
        }
    }
}