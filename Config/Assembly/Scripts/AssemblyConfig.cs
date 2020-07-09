using UnityEngine;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>The assembly config keeps assemby settings.</para>
    /// </summary>
    [CreateAssetMenu(
        fileName = "AssemblyConfig",
        menuName = "Orego/Config/New AssemblyConfig"
    )]
    public class AssemblyConfig : ScriptableObject
    {
        [SerializeField]
        public string[] assemblyNames;
    }
}