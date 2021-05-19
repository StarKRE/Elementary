using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Elementary
{
    /// <summary>
    ///     <para>Utils for this library.</para>
    /// </summary>
    internal static class DictionaryUtils
    {
        /// <summary>
        ///     Finds a value derived from "R".
        /// </summary>
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

            throw new Exception($"Item is not found {requiredType.Name}!");
        }
    }
}