using UnityEngine;

namespace ElementaryFramework.Core
{
    /// <summary>
    ///     <para>Keeps assemby settings.</para>
    /// </summary>
    [CreateAssetMenu(
        fileName = "AssemblyConfig",
        menuName = "Elementary/Config/New AssemblyConfig"
    )]
    public class AssemblyConfig : ScriptableObject
    {
        [SerializeField]
        public string[] assemblyNames;
    }
}