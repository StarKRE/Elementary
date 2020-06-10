using System;

namespace OregoFramework.Util
{
    public static class ObjectUtils
    {
        public static void Apply<T>(this T obj, Action<T> action)
        {
            action?.Invoke(obj);
        }
    }
}