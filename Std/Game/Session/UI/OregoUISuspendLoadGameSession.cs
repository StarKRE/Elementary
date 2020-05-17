using System;
using System.Collections;
using System.Collections.Generic;
using OregoFramework.Tool;
using OregoFramework.Util;

namespace OregoFramework.Game
{
    using UIGameControllers = IEnumerable<IOregoUIGameNode>;

    public abstract class OregoUISuspendLoadGameSession : OregoUINodeGameSession
    {
        #region Event

        public AutoEvent<object> OnGameUILoadedEvent { get; }

        #endregion

        private Routine loadUIRoutine;

        protected OregoUISuspendLoadGameSession()
        {
            this.OnGameUILoadedEvent = this.New<AutoEvent<object>>();
        }

        protected virtual void Awake()
        {
            this.loadUIRoutine = RoutineFactory.CreateInstance();
        }

        public void LoadGameUI(object sender)
        {
            this.loadUIRoutine.Start(this.LoadUIRoutine(sender));
        }

        private IEnumerator LoadUIRoutine(object sender)
        {
            var reference = new Reference<UIGameControllers>();
            yield return Continuation<UIGameControllers>.Suspend(reference, this.OnLoadUISuspend);
            var controllers = reference.value;
            foreach (var controller in controllers)
            {
                this.AddUINode(controller);
            }

            this.OnGameUILoadedEvent?.Invoke(sender);
        }

        protected abstract void OnLoadUISuspend(Continuation<UIGameControllers> continuation);
    }
}