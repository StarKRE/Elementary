using System;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>The condition checks environment of element type
    ///     <see cref="OregoContext.IEnvironment"/>.</para>
    /// </summary>
    public class EnvironmentElementChoiceCondition<T> : ContextElementChoiceCondition
        where T : OregoContext.IEnvironment
    {
        private readonly Type targetEnvironmentType = typeof(T);

        public override bool MatchesElementType(Type elementType)
        {
            if (!this.HasOregoContextAttribute(elementType, out var contextAttribute))
            {
                return false;
            }

            var environmentType = contextAttribute.environmentType;
            return this.MatchesEnvironment(environmentType);
        }

        /// <summary>
        ///     <para>Checks that current environment extends from target environment</para>
        /// </summary>
        /// <param name="environmentType">Current environment type.</param>
        /// <returns></returns>
        protected bool MatchesEnvironment(Type environmentType)
        {
            return environmentType.IsAssignableFrom(this.targetEnvironmentType);
        }
    }
}