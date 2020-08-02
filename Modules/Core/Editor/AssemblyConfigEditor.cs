#if UNITY_EDITOR
using UnityEditor;

namespace ElementaryFramework.Edit
{
    public static class AssemblyConfigEditor
    {
        /// <summary>
        ///     <para>Selects the assembly config. <see cref="AssemblyConfig"/></para>
        /// </summary>
        [MenuItem("Window/Elementary/Config/Show Assembly Config...")]
        private static void SelectConfigAsset()
        {
            const string path =
                "Assets/Elementary/Config/Assembly/Resources/AssemblyConfig.asset";
            Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(path);
        }
    }
}
#endif