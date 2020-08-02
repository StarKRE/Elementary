using UnityEngine;

namespace ElementaryFramework.Unit
{
    /// <summary>
    ///     <para>Keeps settings.</para>
    /// </summary>
    [CreateAssetMenu(
        fileName = "LoggerConfig",
        menuName = "Elementary/Config/New LoggerConfig"
    )]
    public class LoggerConfig : ScriptableObject
    {
        /// <summary>
        ///     <para>Only selected level prints into console.</para>
        /// </summary>
        [SerializeField]
        public string level = LogLevel.DEBUG;

        /// <summary>
        ///     <para>Only selected profile prints into console.</para>
        /// </summary>
        [SerializeField]
        public string profile = "TestProfile";
    }
}