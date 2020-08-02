using System;
using System.Collections.Generic;
using ElementaryFramework.Util;
using UnityEngine;

namespace ElementaryFramework.App
{
    public class UIBackPressController : UIElement, IUIController
    {
        protected readonly Stack<Action> onBackPressActionStack;

        public UIBackPressController()
        {
            this.onBackPressActionStack = new Stack<Action>();
        }

        public void TakeBackPressAction(Action backPressAction)
        {
            this.onBackPressActionStack.Push(backPressAction);
        }

        public void ReleaseBackPressAction(Action backPressAction)
        {
            while (this.onBackPressActionStack.Pop() != backPressAction)
            {
            }
        }

        protected virtual void OnBackPressed()
        {
            if (this.onBackPressActionStack.IsNotEmpty())
            {
                var currentBackPressAction = this.onBackPressActionStack.Peek();
                currentBackPressAction?.Invoke();
            }
        }
    }
}