using System;

namespace OregoFramework.UI
{
    public abstract class OregoUICachedScreen : OregoUIScreen
    {
        protected void StartPreviousScreen(Action<OregoUIScreen> callback = null)
        {
            var parent = this.GetParent<OregoUICachedScreenController>();
            parent.StartPreviousScreen(callback);
        }
    }
}