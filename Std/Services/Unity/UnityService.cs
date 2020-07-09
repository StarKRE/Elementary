using OregoFramework.Core;
using OregoFramework.Util;
using UnityEngine;

namespace OregoFramework.Service
{
    public abstract class UnityService : Service
    {
        #region Event

        public AutoEvent<float> OnUpdateEvent { get; }

        public AutoEvent<float> OnFixedUpdateEvent { get; }

        public AutoEvent OnApplicationPausedEvent { get; }

        public AutoEvent OnApplicationResumedEvent { get; }

        public AutoEvent OnApplicationFocusedEvent { get; }

        public AutoEvent OnApplicationReleasedEvent { get; }

        public AutoEvent OnApplicationQuitEvent { get; }

        #endregion
        
        public float deltaTime { get; private set; }

        public float fixedDeltaTime { get; private set; }

        protected UnityService()
        {
            this.OnUpdateEvent = this.New<AutoEvent<float>>();
            this.OnFixedUpdateEvent = this.New<AutoEvent<float>>();
            this.OnApplicationPausedEvent = this.New<AutoEvent>();
            this.OnApplicationResumedEvent = this.New<AutoEvent>();
            this.OnApplicationFocusedEvent = this.New<AutoEvent>();
            this.OnApplicationReleasedEvent = this.New<AutoEvent>();
            this.OnApplicationQuitEvent = this.New<AutoEvent>();
        }

        protected virtual void Awake()
        {
            this.deltaTime = Time.deltaTime;
            this.fixedDeltaTime = Time.fixedDeltaTime;
        }
        
        private void Update()
        {
            this.OnUpdateEvent?.Invoke(this.deltaTime);
        }

        private void FixedUpdate()
        {
            this.OnFixedUpdateEvent?.Invoke(this.fixedDeltaTime);
        }
        
        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                this.OnApplicationPausedEvent?.Invoke();
            }
            else
            {
                this.OnApplicationResumedEvent?.Invoke();
            }
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus)
            {
                this.OnApplicationFocusedEvent?.Invoke();
            }
            else
            {
                this.OnApplicationReleasedEvent?.Invoke();
            }
        }

        private void OnApplicationQuit()
        {
            this.OnApplicationQuitEvent?.Invoke();
            Orego.Stop();
        }
    }
}