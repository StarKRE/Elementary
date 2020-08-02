using System;
using System.Collections.Generic;

namespace ElementaryFramework.Util
{
    public static class ArrayUtils
    {
        public static T GetRandom<T>(this T[] array)
        {
            if (array.Length == Int.ZERO)
            {
                throw new Exception("Array is empty!");
            }
            
            var random = new Random();
            var randomIndex = random.Next(Int.ZERO, array.Length);
            return array[randomIndex];
        }

        public static T[] ForEach<T>(this T[] array, Action<T> action)
        {
            foreach (var e in array) action?.Invoke(e);

            return array;
        }

        public static bool IsEmpty<T>(this T[] array)
        {
            return array.Length == Int.ZERO;
        }

        public static bool IsNotEmpty<T>(this T[] array)
        {
            return array.Length > 0;
        }
        
        public static T[] Foreach<T>(this T[] array, Action<T> action)
        {
            foreach (var e in array)
            {
                action?.Invoke(e);
            }

            return array;
        }

        public static int LastIndex<T>(this T[] array)
        {
            return array.Length - Int.ONE;
        }
        
        public static T Last<T>(this T[] array)
        {
            return array[array.LastIndex()];
        }
    }
}