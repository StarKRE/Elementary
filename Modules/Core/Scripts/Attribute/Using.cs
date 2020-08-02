using System;

namespace ElementaryFramework.Core
{
    /// <summary>
    ///     <para>Only annotated classes extended from <see cref="IElement"/>
    ///     can be created by framework.</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class Using : Attribute
    {
    }
}