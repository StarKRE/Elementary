using System;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Defines over target annotated class that it belongs
    ///     to the Orego framework system.</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class OregoContext : Attribute
    {
        /// <summary>
        ///     <para>Defines your project environment.</para>
        ///     <example>It's may be Development/QA/Production environment.</example> 
        /// </summary>
        public Type environmentType { get; }

        public OregoContext(Type environmentType)
        {
            this.environmentType = environmentType;
        }

        public OregoContext()
        {
            this.environmentType = typeof(IEnvironment);
        }
        
        /// <summary>
        ///     <para>Base project environment. Create your environment
        ///     extending from this interface.</para>
        /// </summary>
        public interface IEnvironment
        {
        }
    }
}