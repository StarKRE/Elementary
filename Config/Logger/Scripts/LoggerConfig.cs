using UnityEngine;

namespace OregoFramework.Tools
{
    /// <summary>
    ///     <para>The logger config keeps settings.</para>
    /// </summary>
    [CreateAssetMenu(
        fileName = "LoggerConfig",
        menuName = "Orego/Config/New LoggerConfig"
    )]
    public class LoggerConfig : ScriptableObject
    {
        [SerializeField]
        public string level = LogLevel.DEBUG;

        [SerializeField]
        public string profile = "TestProfile";
    }
}