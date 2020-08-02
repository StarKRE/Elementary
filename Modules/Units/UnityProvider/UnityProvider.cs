using ElementaryFramework.Util;
using UnityEngine;

namespace ElementaryFramework.Unit
{
    public sealed class UnityProvider : AutoMonoBehaviour
    {
        #region Const

        private const string NAME = "UnityProvider";

        #endregion
        
        private static UnityProvider _instance;

        private static bool isCreated;

        #region Event

        public AutoEvent<float> OnUpdateEvent { get; }

        public AutoEvent<float> OnFixedUpdateEvent { get; }

        public AutoEvent OnApplicationPausedEvent { get; }

        public AutoEvent OnApplicationResumedEvent { get; }

        public AutoEvent OnApplicationFocusedEvent { get; }

        public AutoEvent OnApplicationReleasedEvent { get; }

        public AutoEvent OnApplicationQuitEvent { get; }

        #endregion
        
        public float unscaledDeltaTime { get; private set; }

        public float fixedDeltaTime { get; private set; }

        public static UnityProvider instance
        {
            get
            {
                if (isCreated)
                {
                    return _instance;
                }

                CreateSingleton(out _instance);
                return _instance;
            }
        }

        private static void CreateSingleton(out UnityProvider singleton)
        {
            var dispatcher = new GameObject(NAME)
            {
                hideFlags = HideFlags.HideAndDontSave
            };
            DontDestroyOnLoad(dispatcher);
            singleton = dispatcher.AddComponent<UnityProvider>();
            isCreated = true;
        }

        private UnityProvider()
        {
            this.OnUpdateEvent = this.New<AutoEvent<float>>();
            this.OnFixedUpdateEvent = this.New<AutoEvent<float>>();
            this.OnApplicationPausedEvent = this.New<AutoEvent>();
            this.OnApplicationResumedEvent = this.New<AutoEvent>();
            this.OnApplicationFocusedEvent = this.New<AutoEvent>();
            this.OnApplicationReleasedEvent = this.New<AutoEvent>();
            this.OnApplicationQuitEvent = this.New<AutoEvent>();
        }

        private void Awake()
        {
            this.unscaledDeltaTime = Time.unscaledDeltaTime;
            this.fixedDeltaTime = Time.fixedDeltaTime;
        }
        
        private void Update()
        {
            this.OnUpdateEvent?.Invoke(this.unscaledDeltaTime);
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
        }
    }
}