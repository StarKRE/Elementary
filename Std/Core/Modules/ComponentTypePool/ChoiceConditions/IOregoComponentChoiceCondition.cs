using System;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Filter interface for adding type into component pool
    ///     <see cref="IOregoComponentTypePool"/>.</para>
    /// </summary>
    public interface IOregoComponentChoiceCondition
    {
        bool MatchesComponentType(Type componentType);
    }
}