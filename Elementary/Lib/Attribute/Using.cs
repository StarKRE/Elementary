using System;

namespace Elementary
{
    /// <summary>
    ///     <para>Only classes annotated this attribute can be instantiated.</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class Using : Attribute
    {
    }
}