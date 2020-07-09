using OregoFramework.Core;

namespace OregoFramework.Tool
{
    /// <summary>
    ///     <para>Abstract controller to report analytics.</para>
    /// </summary>
    public abstract class Analytics : Element, ISingletonElement
    {
        public abstract void OnBecameSingleton();
    }
}