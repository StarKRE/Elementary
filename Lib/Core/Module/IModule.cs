using System;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Base controller interface for deploying your framework system through
    ///     parent controller.</para>
    /// </summary>
    public interface IModule : IDisposable
    {
        /// <summary>
        ///    <para>Invokes after all your modules are created.</para>
        ///     <para>Use this callback to bind your modules to each other.</para> 
        /// </summary>
        /// <param name="core">A controller layer with all your modules.</param>
        /// 
        /// <example>
        /// <code>
        /// 
        /// public override void OnProvideCore(IModularCore core)
        /// {
        ///     base.OnProvideCore(core);
        ///     this.iocContainer = controller.GetModule﹤IocContainer﹥();
        /// }
        /// 
        /// </code>
        /// </example>
        void OnProvideCore(IModularCore core);
    }
}