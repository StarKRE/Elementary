#if UNITY_EDITOR
using UnityEditor;

namespace OregoFramework.Editor
{
    public static class MainConfigEditor
    {
        /// <summary>
        ///     <para>Selects the main config. <see cref="MainConfig"/></para>
        /// </summary>
        [MenuItem("Window/Orego/Config/Show Main Config...")]
        private static void SelectConfigAsset()
        {
            const string path = "Assets/Orego/Config/Main/Resources/MainConfig.asset";
            Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(path);
        }
    }
}
#endif