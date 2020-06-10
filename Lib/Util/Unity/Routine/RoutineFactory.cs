using OregoFramework.Util;
using UnityEngine;

namespace OregoFramework.Tool
{
    public sealed class RoutineFactory : MonoBehaviour
    {
        #region Const

        private const string NAME = "OregoCoroutineRunner";

        #endregion

        private static RoutineFactory _instance;

        private static bool isCreated;

        private static RoutineFactory instance
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

        private static void CreateSingleton(out RoutineFactory singleton)
        {
            var dispatcher = new GameObject(NAME)
            {
                hideFlags = HideFlags.HideAndDontSave
            };
            DontDestroyOnLoad(dispatcher);
            singleton = dispatcher.AddComponent<RoutineFactory>();
            isCreated = true;
        }

        public static Routine CreateInstance()
        {
            return new Routine(instance);
        }
    }
}