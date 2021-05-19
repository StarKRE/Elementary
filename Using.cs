using System;

namespace Elementary
{
    /// <summary>
    ///     <para>The classes derived from <see cref="IElement"/> and
    ///     annotated this attribute can be instantiated.</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class Using : Attribute
    {
    }
}