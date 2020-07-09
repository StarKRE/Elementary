using System;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Filter interface for adding type into element pool
    ///     <see cref="IElementTypePool"/>.</para>
    /// </summary>
    public interface IElementChoiceCondition
    {
        bool MatchesElementType(Type elementType);
    }
}