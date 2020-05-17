using System;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>The condition checks environment of component type
    ///     <see cref="OregoContext.IEnvironment"/>.</para>
    /// </summary>
    public class OregoEnvironmentComponentChoiceCondition<T> : OregoContextComponentChoiceCondition
        where T : OregoContext.IEnvironment
    {
        private readonly Type targetEnvironmentType = typeof(T);

        public override bool MatchesComponentType(Type componentType)
        {
            if (!this.HasOregoContextAttribute(componentType, out var contextAttribute))
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