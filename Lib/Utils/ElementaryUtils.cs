using System;
using System.Collections.Generic;

namespace Elementary
{
    public static class ElementaryUtils
    {
        public static R Find<R, T>(this Dictionary<Type, T> map) where R : T
        {
            return (R) map.Find(typeof(R));
        }

        public static T Find<T>(this Dictionary<Type, T> map, Type requiredType)
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