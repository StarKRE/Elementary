#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace OregoFramework.Editor
{
    public static class OregoClearPlayerPrefs
    {
        [MenuItem("Orego/ClearPlayerPrefs")]
        private static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
#endif