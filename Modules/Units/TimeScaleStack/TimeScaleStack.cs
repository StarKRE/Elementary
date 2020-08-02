using System;
using System.Collections.Generic;
using ElementaryFramework.Core;
using ElementaryFramework.Util;
using UnityEngine;

namespace ElementaryFramework.Unit
{
    public abstract class TimeScaleStack : Element, IRootElement
    {
        #region Const

        public const string EXCEPTION_MESSAGE =
            "OregoTimeStack is absent in context! " +
            "Please create a class derives from OregoTimeStack " +
            "and add attribute OregoContext over the class!";

        #endregion

        private static TimeScaleStack instance;

        private readonly Stack<TimeScale> stack;

        private TimeScale currentScale;

        protected TimeScaleStack()
        {
            this.stack = new Stack<TimeScale>();
        }

        public override void OnCreate(IElementContext context)
        {
            base.OnCreate(context);
            instance = this;
            this.currentScale = new TimeScale(Time.timeScale);
        }
        
        public static void PushScale(TimeScale currentScale)
        {
            instance.PushScaleInternal(currentScale);
        }

        protected virtual void PushScaleInternal(TimeScale currentScale)
        {
            var previousScale = instance.currentScale;
            this.stack.Push(previousScale);
            this.SetTimeScaleNode(currentScale);
        }

        public static void PopScale(TimeScale removedScale)
        {
            instance.PopScaleInternal(removedScale);
        }

        protected virtual void PopScaleInternal(TimeScale removedScale)
        {
            if (this.stack.IsEmpty())
            {
                throw new Exception("Node is absent!");
            }

            if (this.currentScale != removedScale)
            {
                while (this.stack.Peek() != removedScale)
                {
                    this.stack.Pop();
                }
            }

            var previousScale = this.stack.Pop();
            this.SetTimeScaleNode(previousScale);
        }

        private void SetTimeScaleNode(TimeScale currentScale)
        {
            this.currentScale = currentScale;
            Time.timeScale = currentScale.value;
        }
    }
}