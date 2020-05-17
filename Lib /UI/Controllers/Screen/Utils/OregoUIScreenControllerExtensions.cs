using System;

namespace OregoFramework.UI
{
    public static class OregoUIScreenControllerExtensions
    {
        public static void StartScreen<T>(
            this OregoUIScreenController controller,
            Action<T> callback = null
        )
            where T : OregoUIScreen
        {
            controller.StartScreen(typeof(T), window => callback?.Invoke((T) window));
        }
    }
}