using System;
using System.Collections;
using System.Collections.Generic;
using OregoFramework.Core;
using OregoFramework.Util;
using UnityEngine;
using Object = UnityEngine.Object;

namespace OregoFramework.Tool
{
    /// <summary>
    ///     <para>Loads resources instead invoking of method "Resources.Load".</para>
    ///     <para>Keeps lightweight resource instances instead assets.</para>
    ///     <para>Uses for avoid hardcoding string path.</para>
    /// </summary>
    public abstract class OregoResourcer : OregoComponentLayer<IOregoResource>,
        IOregoSingletonComponent
    {
        #region Const

        public static readonly string EXCEPTION_MESSAGE =
            $"{nameof(OregoResourcer)} is absent in context! " +
            $"Please create a class derived from {nameof(OregoResourcer)} " +
            $"and add attribute {nameof(OregoContext)} over the class!";

        #endregion

        private static OregoResourcer instance;

        #region OnBecameSingleton

        public void OnBecameSingleton()
        {
            instance = this;
            Orego.AddObject(nameof(OregoResourcer), this);
        }

        #endregion

        #region Get

        public static IEnumerable<T> GetResources<T>() where T : IOregoResource
        {
            return instance.GetComponents<T>();
        }

        public static IEnumerable<IOregoResource> GetResources()
        {
            return instance.allComponents;
        }

        public static T GetResource<T>() where T : IOregoResource
        {
            return (T) instance[typeof(T)];
        }

        #endregion

        #region Load

        public static T Load<T>(Type resourceType) where T : Object
        {
            var resourceInfo = instance[resourceType];
            return Load<T>(resourceInfo);
        }

        public static T Load<T>(IOregoResource resource) where T : Object
        {
            var resourcePath = resource.path;
            return Resources.Load<T>(resourcePath);
        }

        #endregion

        #region AsyncLoad

        public static IEnumerator LoadAsync<T>(Type resouceType, Reference<T> result)
            where T : Object
        {
            var resourceInfo = instance[resouceType];
            yield return LoadAsync(resourceInfo, result);
        }

        public static IEnumerator LoadAsync<T>(IOregoResource resource, Reference<T> result)
            where T : Object
        {
            yield return LoadAsync(resource.path, result);
        }

        public static IEnumerator LoadAsync<T>(string path, Reference<T> result) where T : Object
        {
            var request = Resources.LoadAsync<T>(path);
            yield return request;
            var asset = request.asset;
            result.value = (T) asset;
        }

        #endregion
    }
}