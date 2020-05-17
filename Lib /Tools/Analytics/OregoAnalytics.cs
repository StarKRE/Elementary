using OregoFramework.Core;

namespace OregoFramework.Tool
{
    /// <summary>
    ///     <para>Abstract controller to report analytics.</para>
    /// </summary>
    public abstract class OregoAnalytics : OregoComponent, IOregoSingletonComponent
    {
        public abstract void OnBecameSingleton();
    }
}