using System;
using System.Collections.Generic;
using UnityEngine;

namespace OregoFramework.Core
{
    /// <summary>
    ///    <para>Main class in the Orego Framework.</para>
    ///     <para>Type Orego.Start() to launch the framework.</para>
    /// </summary>
    public static class Orego
    {
        #region Const

        public const string DEFAULT_CONFIG_NAME = "MainConfig";

        #endregion

        /// <summary>
        ///     <para>Indicates is framework started.</para>
        /// </summary>
        public static bool isStarted { get; private set; }

        /// <summary>
        ///     <para>Core of the framework.</para>
        /// </summary>
        private static ICore core;

        /// <summary>
        ///     <para>Map of global object references.</para>
        /// </summary>
        private static readonly Dictionary<string, object> objectMap;

        static Orego()
        {
            objectMap = new Dictionary<string, object>();
        }

        /// <summary>
        ///     <para>Deploys the framework.</para>
        /// </summary>
        ///    <param name="configPath">The path to config asset of framework in Resources.
        ///     By default the name of path is "MainConfig".</param>
        /// <exception cref="Exception">Orego Framework has already launched!</exception>
        /// <exception cref="Exception">Core type is not found!</exception>
        public static void Start(string configPath = DEFAULT_CONFIG_NAME)
        {
            if (isStarted)
            {
                throw new Exception("Orego Framework has already launched");
            }

            isStarted = true;
            var asset = Resources.Load<MainConfig>(configPath);
            var controllerTypeName = asset.coreTypeName;
            var controllerType = Type.GetType(controllerTypeName);
            var type = controllerType;
            if (type is null)
            {
                throw new Exception($"Core type {controllerTypeName} is not found!");
            }

            core = (ICore) Activator.CreateInstance(type);
            core.Install();
            Resources.UnloadAsset(asset);
        }

        /// <summary>
        ///     <para>Collapses the framework.</para>
        /// </summary>
        /// <exception cref="Exception">Orego Framework has not launched yet!</exception>
        public static void Stop()
        {
            if (!isStarted)
            {
                throw new Exception("Orego Framework has not launched yet!");
            }

            isStarted = false;
            core.Uninstall();
            core = null;
        }

        /// <summary>
        ///     <param name="id">Object id.</param>
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <returns>Object reference.</returns>
        public static T GetObject<T>(string id)
        {
            return (T) objectMap[id];
        }

        /// <summary>
        ///     <para>Checks if a single object is contained in the global map.</para>
        /// </summary>
        /// <param name="id">object id.</param>
        /// <returns>True/False.</returns>
        public static bool HasObject(string id)
        {
            return objectMap.ContainsKey(id);
        }

        /// <summary>
        ///     <para>Addes object to global map.</para>
        /// </summary>
        /// <param name="id">Object id - key.</param>
        /// <param name="obj">Object reference - value.</param>
        public static void AddObject(string id, object obj)
        {
            objectMap.Add(id, obj);
        }
        
        /// <summary>
        ///     <para>Removes object reference from global map.</para>
        /// </summary>
        /// <param name="id">Object id.</param>
        public static void RemoveObject(string id)
        {
            objectMap.Remove(id);
        }
        
        /// <summary>
        ///     <para>Responsibles for installing and uninstalling of
        ///     your framework system.</para>
        /// </summary>
        public interface ICore
        {
            /// <summary>
            ///     <para>Use this methdod for deploy your framework system.</para>
            /// </summary>
            void Install();

            /// <summary>
            ///     <para>Use this method to dispose your framework system.</para>
            /// </summary>
            void Uninstall();
        }
    }
}