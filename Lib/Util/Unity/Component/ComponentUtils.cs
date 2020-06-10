using System;
using UnityEngine;

namespace OregoFramework.Util
{
    public static class ComponentUtils
    {
        public static bool HasComponent<T>(this Component component, out T result)
        {
            var requiredComponent = component.GetComponent<T>();
            if (requiredComponent != null)
            {
                result = requiredComponent;
                return true;
            }

            result = default(T);
            return false;
        }
        
        public static bool HasComponent<T>(this Component component)
        {
            return component.GetComponent<T>() != null;
        }
        
        public static bool HasComponent(this Component component, Type type)
        {
            return component.GetComponent(type) != null;
        }
        
        public static void SetInvisible(this Component component)
        {
            component.gameObject.SetActive(false);
        }

        public static void SetVisible(this Component component)
        {
            component.gameObject.SetActive(true);
        }
    }
}