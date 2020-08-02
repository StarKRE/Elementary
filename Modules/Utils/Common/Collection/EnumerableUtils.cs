using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementaryFramework.Util
{
    public static class EnumerableUtils
    {
        public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
        {
            return !enumerable.Any();
        }

        public static bool IsNotEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Any();
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action?.Invoke(item);
            }
        }

        public static T GetRandomWhile<T>(
            this IEnumerable<T> set,
            out bool isFound,
            Func<T, bool> condition
        )
        {
            var list = new System.Collections.Generic.List<T>(set);
            while (list.IsNotEmpty())
            {
                var item = list.GetRandom();
                if (condition(item))
                {
                    isFound = true;
                    return item;
                }

                list.Remove(item);
            }

            isFound = false;
            return default(T);
        }

        public static T GetRandom<T>(this IEnumerable<T> enumerable)
        {
            var random = new Random();
            var randomIndex = random.Next(Int.ZERO, enumerable.Count());
            var currentIndex = Int.ZERO;
            foreach (var item in enumerable)
            {
                if (currentIndex == randomIndex)
                {
                    return item;
                }

                currentIndex++;
            }

            throw new Exception("Enumerable is empty!");
        }

        public static void ForRandomByOnce<T>(this IEnumerable<T> set, int count, Action<T> action)
        {
            var setCount = set.Count();
            if (count >= setCount)
            {
                throw new Exception($"Selection count {count} more than item count {setCount}!");
            }

            var list = new System.Collections.Generic.List<T>(set);
            var pointer = Int.ZERO;
            while (pointer < count)
            {
                var item = list.GetRandom();
                action.Invoke(item);
                list.Remove(item);
                pointer++;
            }
        }

        public static IEnumerable<T> GetRandomSet<T>(this IEnumerable<T> enumerable, int count)
        {
            if (enumerable.Count() < count)
            {
                throw new Exception("Required count more than enumerable size!");
            }

            var restItems = enumerable.ToList();
            var resultRandomList = new List<T>();
            for (var i = Int.ZERO; i < count; i++)
            {
                var randomItem = restItems.GetRandom();
                resultRandomList.Add(randomItem);
                restItems.Remove(randomItem);
            }

            return resultRandomList;
        }
    }
}