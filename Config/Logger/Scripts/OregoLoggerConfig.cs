using OregoFramework.Util;
using UnityEngine;

namespace OregoFramework.Tools
{
    /// <summary>
    ///     <para>The logger config keeps settings.</para>
    /// </summary>
    [CreateAssetMenu(
        fileName = "OregoLoggerConfig",
        menuName = "Orego/Config/New OregoLoggerConfig"
    )]
    public class OregoLoggerConfig : AutoScriptableObject
    {
        [SerializeField]
        public string level = LogLevel.DEBUG;

        [SerializeField]
        public string profile = "TestProfile";
    }
}