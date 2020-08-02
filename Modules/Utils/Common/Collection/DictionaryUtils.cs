using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ElementaryFramework.Util
{
    public static class DictionaryUtils
    {
        public static Dictionary<K, V> Copy<K, V>(this Dictionary<K, V> originMap)
        {
            return new Dictionary<K, V>(originMap);
        }

        public static Dictionary<Type, T> ToDictionary<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.ToDictionary(it => it.GetType());
        }

        public static void AddByType<T>(this Dictionary<Type, T> map, T item)
        {
            map.Add(item.GetType(), item);
        }

        public static void RemoveByType<T>(this Dictionary<Type, T> map, T item)
        {
            map.Remove(item.GetType());
        }

        public static void AddAllByType<T>(this Dictionary<Type, T> map, IEnumerable<T> enumerable)
        {
            foreach (var item in enumerable)
            {
                map.AddByType(item);
            }
        }

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

            throw new Exception("Item not found!");
        }

        public static bool TryFind<T>(this Dictionary<Type, T> map, Type requiredType, out T item)
        {
            if (map.ContainsKey(requiredType))
            {
                item =  map[requiredType];
                return true;
            }

            var keys = map.Keys;
            foreach (var key in keys)
            {
                if (requiredType.IsAssignableFrom(key))
                {
                    item = map[key];
                    return true;
                }
            }

            item = default;
            return false;
        }

        public static IEnumerable<R> FindAll<R, T>(this Dictionary<Type, T> map) where R : T
        {
            return map.Values.OfType<R>();
        }
    }
}