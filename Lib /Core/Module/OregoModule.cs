namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Base abstract implementation of <see cref="IOregoModule"/>.</para>
    /// </summary>
    public abstract class OregoModule : IOregoModule
    {
        public virtual void OnBindConfig(IOregoModularConfig config)
        {
        }

        public virtual void Dispose()
        {
        }
    }
}