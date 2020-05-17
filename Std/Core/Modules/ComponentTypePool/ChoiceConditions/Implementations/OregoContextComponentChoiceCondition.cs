using System;
using System.Reflection;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>The condition checks attribute <see cref="OregoContext"/> over type.</para>
    /// </summary>
    public class OregoContextComponentChoiceCondition : IOregoComponentChoiceCondition
    {
        public virtual bool MatchesComponentType(Type componentType)
        {
            return HasOregoContextAttribute(componentType, out _);
        }
        
        protected bool HasOregoContextAttribute(Type componentType, out OregoContext contextAttribute)
        {
            contextAttribute = componentType.GetCustomAttribute<OregoContext>();
            return contextAttribute != null;
        }
    }
}