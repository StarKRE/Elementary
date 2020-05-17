using OregoFramework.Util;
using UnityEngine;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>The assembly config keeps assemby settings.</para>
    /// </summary>
    [CreateAssetMenu(
        fileName = "OregoAssemblyConfig",
        menuName = "Orego/Config/New OregoAssemblyConfig"
    )]
    public class OregoAssemblyConfig : AutoScriptableObject
    {
        [SerializeField]
        public string[] assemblyNames;
    }
}