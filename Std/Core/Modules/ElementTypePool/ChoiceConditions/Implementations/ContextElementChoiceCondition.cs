using System;
using System.Reflection;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>The condition checks attribute <see cref="OregoContext"/> over type.</para>
    /// </summary>
    public class ContextElementChoiceCondition : IElementChoiceCondition
    {
        public virtual bool MatchesElementType(Type elementType)
        {
            return HasOregoContextAttribute(elementType, out _);
        }
        
        protected bool HasOregoContextAttribute(Type elementType, out OregoContext contextAttribute)
        {
            contextAttribute = elementType.GetCustomAttribute<OregoContext>();
            return contextAttribute != null;
        }
    }
}