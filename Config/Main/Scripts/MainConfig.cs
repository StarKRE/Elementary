using UnityEngine;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Keeps main core type <see cref="Orego.ICore"/>
    ///     that is responsible for installing and uninstalling of
    ///     your framework system.</para>
    /// </summary>
    [CreateAssetMenu(
        fileName = "MainConfig",
        menuName = "Orego/Config/New MainConfig"
    )]
    public sealed class MainConfig : ScriptableObject
    {
        [SerializeField]
        public string coreTypeName = "OregoFramework.Core.StandardCore";
    }
}