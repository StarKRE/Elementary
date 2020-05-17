using System.Collections.Generic;
using UnityEngine;

namespace OregoFramework.Util
{
    public static class FindComponentUtils
    {
        public static IEnumerable<T> FindChildrenRecursively<T>(this Component component)
        {
            var requieredComponents = new List<T>();
            var transform = component.transform;
            var childCount = transform.childCount;
            for (var i = 0; i < childCount; i++)
            {
                var childTransform = transform.GetChild(i);
                requieredComponents.AddRange(childTransform.GetComponentsInChildren<T>());
            }

            return requieredComponents;
        }
    }
}