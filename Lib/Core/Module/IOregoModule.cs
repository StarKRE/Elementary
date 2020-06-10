using System;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Base controller interface for deploying your framework system through
    ///     parent config.</para>
    /// </summary>
    public interface IOregoModule : IDisposable
    {
        /// <summary>
        ///    <para>Invokes after all your modules are created.</para>
        ///     <para>Use this callback to bind your modules to each other.</para> 
        /// </summary>
        /// <param name="config">A config layer with all your modules.</param>
        /// 
        /// <example>
        /// <code>
        /// 
        /// public override void OnBindConfig(IOregoModularConfig config)
        /// {
        ///     base.OnBindConfig(config);
        ///     this.iocContainer = config.GetModule﹤IocContainer﹥();
        /// }
        /// 
        /// </code>
        /// </example>
        void OnBindConfig(IOregoModularConfig config);
    }
}