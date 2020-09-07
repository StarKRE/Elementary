using System;
using System.Collections.Generic;

namespace Elementary
{
    /// <summary>
    ///     <para>Utils for this library.</para>
    /// </summary>
    internal static class ElementaryUtils
    {
        /// <summary>
        ///     Finds a value inherited from "R".
        /// </summary>
        /// <param name="map">Dictionary</param>
        /// <typeparam name="R">Required type.</typeparam>
        /// <typeparam name="T">Dictionary value type.</typeparam>
        /// <returns>Required value.</returns>
        internal static R Find<R, T>(this Dictionary<Type, T> map)
        {
            return (R) map.Find(typeof(R));
        }

        private static object Find<T>(this Dictionary<Type, T> map, Type requiredType)
        {
            if (map.ContainsKey(requiredType))
            {
                return map[requiredType];
            }

            var keys = map.Keys;
            foreach (var key in keys)
            {
                if (requiredType.IsAssignableFrom(key))
                {
                    return map[key];
                }
            }

            throw new Exception("Value not found!");
        }
    }
}