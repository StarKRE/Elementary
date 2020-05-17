using UnityEditor;

namespace OregoFramework.Editor
{
    public static class OregoAssemblyConfigTools
    {
        /// <summary>
        ///     <para>Selects the assembly config. <see cref="OregoAssemblyConfig"/></para>
        /// </summary>
        [MenuItem("Window/Orego/Config/Show Assembly Config...")]
        private static void SelectConfigAsset()
        {
            const string path =
                "Assets/Plugins/Orego/Config/Assembly/Resources/OregoAssemblyConfig.asset";
            Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(path);
        }
    }
}