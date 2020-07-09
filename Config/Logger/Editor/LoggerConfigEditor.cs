#if UNITY_EDITOR
using UnityEditor;

namespace OregoFramework.Editor
{
    public static class LoggerConfigEditor
    {
        /// <summary>
        ///     <para>Selects the logger config. <see cref="LoggerConfig"/></para>
        /// </summary>
        [MenuItem("Window/Orego/Config/Show Logger Config...")]
        private static void SelectAssemblyConfigAsset()
        {
            const string path =
                "Assets/Plugins/Orego/Config/Logger/Resources/LoggerConfig.asset";
            Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(path);
        }
    }
}
#endif