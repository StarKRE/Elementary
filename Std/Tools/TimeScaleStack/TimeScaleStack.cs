using System;
using System.Collections.Generic;
using OregoFramework.Core;
using OregoFramework.Util;
using UnityEngine;

namespace OregoFramework.Tool
{
    public abstract class TimeScaleStack : Element, ISingletonElement
    {
        #region Const

        public const string EXCEPTION_MESSAGE =
            "OregoTimeStack is absent in context! " +
            "Please create a class derives from OregoTimeStack " +
            "and add attribute OregoContext over the class!";

        #endregion

        private static TimeScaleStack instance;

        private readonly Stack<TimeScaleNode> stack;

        private TimeScaleNode currentTimeScaleNode;

        protected TimeScaleStack()
        {
            this.stack = new Stack<TimeScaleNode>();
        }

        #region OnBecameSingleton

        public void OnBecameSingleton()
        {
            instance = this;
            Orego.AddObject(nameof(TimeScaleStack), this);
        }

        #endregion

        #region OnCreate

        public override void OnCreate()
        {
            base.OnCreate();
            this.currentTimeScaleNode = new TimeScaleNode(Time.timeScale);
        }

        #endregion

        public static void PushScale(TimeScaleNode currentNode)
        {
            instance.PushScaleInternal(currentNode);
        }

        protected virtual void PushScaleInternal(TimeScaleNode currentNode)
        {
            var previousNode = instance.currentTimeScaleNode;
            this.stack.Push(previousNode);
            this.SetTimeScaleNode(currentNode);
        }

        public static void PopScale(TimeScaleNode removedNode)
        {
            instance.PopScaleInternal(removedNode);
        }

        protected virtual void PopScaleInternal(TimeScaleNode removedNode)
        {
            if (this.stack.IsEmpty())
            {
                throw new Exception("Node is absent!");
            }

            if (this.currentTimeScaleNode != removedNode)
            {
                while (this.stack.Peek() != removedNode)
                {
                    this.stack.Pop();
                }
            }

            var previousNode = this.stack.Pop();
            this.SetTimeScaleNode(previousNode);
        }

        private void SetTimeScaleNode(TimeScaleNode currentNode)
        {
            this.currentTimeScaleNode = currentNode;
            Time.timeScale = currentNode.timeScale;
        }
    }
}