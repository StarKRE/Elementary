using UnityEngine;
using UnityEngine.EventSystems;

namespace OregoFramework.Game
{
    public abstract class OregoUIGameInput : OregoUIGameNode
    {
        protected EventSystem eventSystem { get; private set; }

        protected virtual void Awake()
        {
            this.enabled = false;
        }

        public override void OnGamePrepared(object sender)
        {
            base.OnGamePrepared(sender);
            this.eventSystem = EventSystem.current;
        }

        public override void OnGameStarted(object sender)
        {
            base.OnGameStarted(sender);
            this.enabled = true;
        }

        public override void OnGamePaused(object sender)
        {
            base.OnGamePaused(sender);
            this.enabled = false;
        }

        public override void OnGameResumed(object sender)
        {
            base.OnGameResumed(sender);
            this.enabled = true;
        }

        public override void OnGameFinished(object sender)
        {
            base.OnGameFinished(sender);
            this.enabled = false;
        }

        //For touch!
        protected bool IsPointerOverGameObject(Touch touch)
        {
            return this.eventSystem.IsPointerOverGameObject(touch.fingerId);
        }

        //For mouse:
        protected bool IsPointerOverGameObject()
        {
            return this.eventSystem.IsPointerOverGameObject();
        }
    }
}