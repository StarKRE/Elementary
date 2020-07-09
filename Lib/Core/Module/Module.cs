namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Base abstract implementation of <see cref="IModule"/>.</para>
    /// </summary>
    public abstract class Module : IModule
    {
        public virtual void OnProvideCore(IModularCore core)
        {
        }

        public virtual void Dispose()
        {
        }
    }
}