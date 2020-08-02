using System;
using UnityEngine;

namespace ElementaryFramework.Core
{
    /// <summary>
    ///    <para>Main class in the Elementary Framework.</para>
    ///     <para>Type Elementary.Initialize() to launch the framework.</para>
    /// </summary>
    public static class Elementary
    {
        #region Const

        public const string DEFAULT_CONFIG_NAME = "CoreConfig";

        #endregion

        public static bool isInitialized { get; private set; }

        /// <summary>
        ///     <para>Controls all framework system.</para>
        /// </summary>
        private static ICore core;

        /// <summary>
        ///     <para>Launches the framework.</para>
        /// </summary>
        ///    <param name="configPath">The path to the config asset of framework in Resources.
        ///     By default the name of path is "CoreConfig".</param>
        /// <exception cref="Exception">Elementary Framework has already launched!</exception>
        /// <exception cref="Exception">Core type is not found!</exception>
        public static void Initialize(string configPath = DEFAULT_CONFIG_NAME)
        {
            if (isInitialized)
            {
                throw new Exception("Elementary Framework has already launched");
            }

            isInitialized = true;
            var asset = Resources.Load<CoreConfig>(configPath);
            var coreClassFullName = asset.coreTypeName;
            var coreClass = Type.GetType(coreClassFullName);
            if (coreClass is null)
            {
                throw new Exception($"Core class {coreClassFullName} is not found!");
            }

            core = (ICore) Activator.CreateInstance(coreClass);
            core.Initialize();
        }

        /// <summary>
        ///     <para>Finalizes the framework.</para>
        /// </summary>
        /// <exception cref="Exception">Elementary Framework has not launched yet!</exception>
        public static void Terminate()
        {
            if (!isInitialized)
            {
                throw new Exception("Elementary Framework has not launched yet!");
            }

            isInitialized = false;
            core.Terminate();
            core = null;
        }
        
        public static T GetCore<T>() where T : ICore
        {
            return (T) core;
        }

        /// <summary>
        ///     <para>Controls all framework system.</para>
        /// </summary>
        public interface ICore
        {
            /// <summary>
            ///     <para>Use this method to init your framework system.</para>
            /// </summary>
            void Initialize();

            /// <summary>
            ///     <para>Use this method to finalize your framework system.</para>
            /// </summary>
            void Terminate();
        }
    }
}