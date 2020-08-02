using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ElementaryFramework.Util
{
    public static class GameObjectUtils
    {
        public static bool HasComponent<T>(this GameObject myObject)
        {
            return myObject.GetComponent<T>() != null;
        }
        
        public static bool HasComponent<T>(this GameObject component, out T result)
        {
            var requiredComponent = component.GetComponent<T>();
            if (requiredComponent != null)
            {
                result = requiredComponent;
                return true;
            }

            result = default;
            return false;
        }

        public static bool HasComponent(this GameObject myObject, Type type)
        {
            return myObject.GetComponent(type) != null;
        }

        public static void SetInvisible(this GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        public static void SetVisible(this GameObject gameObject)
        {
            gameObject.SetActive(true);
        }
    }
}