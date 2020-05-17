using OregoFramework.Util;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>The main config is responsible for installing and uninstalling of
    ///     your framework system.</para>
    /// </summary>
    public abstract class OregoMainConfig : AutoScriptableObject
    {
        /// <summary>
        ///     <para>Use this methdod for deploy your framework system.</para>
        /// </summary>
        public abstract void Install();

        /// <summary>
        ///     <para>Use this method to dispose your framework system.</para>
        /// </summary>
        public abstract void Uninstall();
    }
}