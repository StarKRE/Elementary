using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OregoFramework.Util
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
            var type = keys.First(requiredType.IsAssignableFrom);
            return map[type];
        }

        public static IEnumerable<R> FindAll<R, T>(this Dictionary<Type, T> map) where R : T
        {
            return map.Values.OfType<R>();
        }
    }
}