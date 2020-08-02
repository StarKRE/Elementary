using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementaryFramework.Util
{
    public static class ListUtils
    {
        #region Const

        private const int FIRST_INDEX = 0;

        #endregion

        public static int GetRandomIndex<T>(this List<T> collection)
        {
            if (collection.IsEmpty())
            {
                throw new Exception("List is empty!");
            }

            var randomIndex = new Random().Next(Int.ZERO, collection.Count);
            return randomIndex;
        }

        public static T GetRandom<T>(this List<T> collection)
        {
            var randomIndex = collection.GetRandomIndex();
            return collection[randomIndex];
        }

        public static bool IsEmpty<T>(this List<T> list)
        {
            return list.Count == Int.ZERO;
        }

        public static bool IsNotEmpty<T>(this List<T> list)
        {
            return list.Count > Int.ZERO;
        }

        public static int LastIndex<T>(this List<T> list)
        {
            return list.Count - Int.ONE;
        }

        public static T Last<T>(this List<T> list)
        {
            var lastIndex = list.LastIndex();
            return list[lastIndex];
        }
    }
}