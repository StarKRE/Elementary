using System;
using System.Collections.Generic;
using OregoFramework.Util;

namespace OregoFramework.UI
{
    public abstract class UICachedScreenController : UIScreenController
    {
        private readonly Stack<Type> previousScreensStack;

        protected UICachedScreenController()
        {
            this.previousScreensStack = new Stack<Type>();
        }

        public override void StartScreen(Type windowType, Action<UIScreen> callback = null)
        {
            var previousScreen = this.currentScreen;
            if (previousScreen != null)
            {
                var previousScreenType = previousScreen.GetType();
                this.previousScreensStack.Push(previousScreenType);
            }

            base.StartScreen(windowType, callback);
        }

        public virtual void StartPreviousScreen(Action<UIScreen> callback = null)
        {
            var nextScreenType = !this.previousScreensStack.IsEmpty()
                ? this.previousScreensStack.Pop()
                : this.GetDefaultScreenType();
            base.StartScreen(nextScreenType, callback);
        }

        public void ClearPreviousScreenStack()
        {
            this.previousScreensStack.Clear();
        }
    }
}