using System;
using System.Collections.Generic;
using OregoFramework.Core;
using OregoFramework.Util;
using UnityEngine;

namespace OregoFramework.Tool
{
    public abstract class OregoTimeScaleStack : OregoComponent, IOregoSingletonComponent
    {
        #region Const

        public const string EXCEPTION_MESSAGE =
            "OregoTimeStack is absent in context! " +
            "Please create a class derives from OregoTimeStack " +
            "and add attribute OregoContext over the class!";

        #endregion

        private static OregoTimeScaleStack instance;

        private readonly Stack<OregoTimeScaleNode> stack;

        private OregoTimeScaleNode currentTimeScaleNode;

        protected OregoTimeScaleStack()
        {
            this.stack = new Stack<OregoTimeScaleNode>();
        }

        #region OnBecameSingleton

        public void OnBecameSingleton()
        {
            instance = this;
            Orego.AddObject(nameof(OregoTimeScaleStack), this);
        }

        #endregion

        #region OnCreate

        public override void OnCreate()
        {
            base.OnCreate();
            this.currentTimeScaleNode = new OregoTimeScaleNode(Time.timeScale);
        }

        #endregion

        public static void PushScale(OregoTimeScaleNode currentNode)
        {
            instance.PushScaleInternal(currentNode);
        }

        protected virtual void PushScaleInternal(OregoTimeScaleNode currentNode)
        {
            var previousNode = instance.currentTimeScaleNode;
            this.stack.Push(previousNode);
            this.SetTimeScaleNode(currentNode);
        }

        public static void PopScale(OregoTimeScaleNode removedNode)
        {
            instance.PopScaleInternal(removedNode);
        }

        protected virtual void PopScaleInternal(OregoTimeScaleNode removedNode)
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

        private void SetTimeScaleNode(OregoTimeScaleNode currentNode)
        {
            this.currentTimeScaleNode = currentNode;
            Time.timeScale = currentNode.timeScale;
        }
    }
}