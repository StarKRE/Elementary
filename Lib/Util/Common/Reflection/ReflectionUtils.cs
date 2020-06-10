using System;

namespace OregoFramework.Util
{
    public static class ReflectionUtils
    {
        public static T CreateInstanceWithReflection<T>(Type type)
        {
            return (T) CreateInstanceWithReflection(type);
        }

        public static object CreateInstanceWithReflection(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
}