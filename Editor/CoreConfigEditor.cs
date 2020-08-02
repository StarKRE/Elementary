#if UNITY_EDITOR
using UnityEditor;

namespace ElementaryFramework.Edit
{
    public static class CoreConfigEditor
    {
        /// <summary>
        ///     <para>Selects the config. <see cref="CoreConfig"/></para>
        /// </summary>
        [MenuItem("Window/Elementary/Config/Show Core Config...")]
        private static void SelectConfigAsset()
        {
            const string path = "Assets/Elementary/Config/Core/Resources/CoreConfig.asset";
            Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(path);
        }
    }
}
#endif