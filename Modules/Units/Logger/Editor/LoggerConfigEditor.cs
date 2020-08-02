#if UNITY_EDITOR
using UnityEditor;

namespace ElementaryFramework.Edit
{
    public static class LoggerConfigEditor
    {
        /// <summary>
        ///     <para>Selects the logger config. <see cref="LoggerConfig"/></para>
        /// </summary>
        [MenuItem("Window/Elementary/Config/Show Logger Config...")]
        private static void SelectAssemblyConfigAsset()
        {
            const string path =
                "Assets/Elementary/Modules/Units/Logger/Resources/LoggerConfig.asset";
            Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(path);
        }
    }
}
#endif