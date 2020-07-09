#if UNITY_EDITOR
using UnityEditor;

namespace OregoFramework.Editor
{
    public static class AssemblyConfigEditor
    {
        /// <summary>
        ///     <para>Selects the assembly config. <see cref="AssemblyConfig"/></para>
        /// </summary>
        [MenuItem("Window/Orego/Config/Show Assembly Config...")]
        private static void SelectConfigAsset()
        {
            const string path =
                "Assets/Plugins/Orego/Config/Assembly/Resources/AssemblyConfig.asset";
            Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(path);
        }
    }
}
#endif