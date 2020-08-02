using UnityEngine;

namespace ElementaryFramework.Core
{
    /// <summary>
    ///     <para>Keeps main core type <see cref="Elementary.ICore"/>
    ///     that maintains the framework system.</para>
    /// </summary>
    [CreateAssetMenu(
        fileName = "CoreConfig",
        menuName = "Orego/Config/New CoreConfig"
    )]
    public sealed class CoreConfig : ScriptableObject
    {
        [SerializeField]
        public string coreTypeName = "ElementaryFramework.Core.ElementContext";
    }
}