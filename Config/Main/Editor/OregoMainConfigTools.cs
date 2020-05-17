#if UNITY_EDITOR
using UnityEditor;

namespace OregoFramework.Editor
{
    public static class OregoMainConfigTools
    {
        /// <summary>
        ///     <para>Selects the main config. <see cref="OregoMainConfig"/></para>
        /// </summary>
        [MenuItem("Window/Orego/Config/Show Main Config...")]
        private static void SelectConfigAsset()
        {
            const string path = "Assets/Plugins/Orego/Config/Main/Resources/OregoMainConfig.asset";
            Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(path);
        }
    }
}
#endif