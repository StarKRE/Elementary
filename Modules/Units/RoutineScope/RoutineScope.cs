using System.Collections;
using ElementaryFramework.Util;
using UnityEngine;

namespace ElementaryFramework.Unit
{
    public sealed class RoutineScope : MonoBehaviour
    {
        #region Const

        private const string NAME = "RoutineScope";

        #endregion

        private static RoutineScope _instance;

        private static bool isCreated;

        private static RoutineScope instance
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

        private static void CreateSingleton(out RoutineScope singleton)
        {
            var dispatcher = new GameObject(NAME)
            {
                hideFlags = HideFlags.HideAndDontSave
            };
            DontDestroyOnLoad(dispatcher);
            singleton = dispatcher.AddComponent<RoutineScope>();
            isCreated = true;
        }

        public static Routine NewRoutine()
        {
            return new Routine(instance);
        }

        public static Coroutine LaunchCoroutine(IEnumerator routine)
        {
            return instance.StartCoroutine(routine);
        }
    }
}