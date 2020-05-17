using System;
using System.Collections.Generic;
using OregoFramework.Util;
using UnityEngine;

namespace OregoFramework.UI
{
    public class OregoBackPressController : OregoUIElement, IOregoUIController
    {
        protected readonly Stack<Action> onBackPressActionStack;

        public OregoBackPressController()
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