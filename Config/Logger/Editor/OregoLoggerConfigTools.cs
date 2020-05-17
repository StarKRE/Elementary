using UnityEditor;

namespace OregoFramework.Editor
{
    public static class OregoLoggerConfigTools
    {
        /// <summary>
        ///     <para>Selects the logger config. <see cref="OregoLoggerConfig"/></para>
        /// </summary>
        [MenuItem("Window/Orego/Config/Show Logger Config...")]
        private static void SelectAssemblyConfigAsset()
        {
            const string path =
                "Assets/Plugins/Orego/Config/Logger/Resources/OregoLoggerConfig.asset";
            Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(path);
        }
    }
}