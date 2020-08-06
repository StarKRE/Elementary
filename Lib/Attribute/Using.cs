using System;

namespace Elementary
{
    /// <summary>
    ///     <para>A target class will be used as element instance.</para>
    ///     <para>The element context can create instances only with this attribuute.</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class Using : Attribute
    {
    }
}