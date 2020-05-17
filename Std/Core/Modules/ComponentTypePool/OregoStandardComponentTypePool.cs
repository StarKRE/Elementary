using System;
using System.Collections.Generic;
using OregoFramework.Util;
using UnityEngine;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Standard implementation of component type pool.</para>
    /// </summary>
    public class OregoStandardComponentTypePool : OregoComponentTypePool
    {
        #region Const

        public const string CONFIG_NAME = "OregoAssemblyConfig";

        #endregion

        protected virtual IOregoComponentChoiceCondition choiceCondition { get; } =
            new OregoEnvironmentComponentChoiceCondition<OregoContext.IEnvironment>();

        protected virtual Type rootType { get; } =
            typeof(IOregoComponent);

        protected HashSet<string> assemblyNames { get; private set; }

        #region Initialize

        public override void OnBindConfig(IOregoModularConfig config)
        {
            base.OnBindConfig(config);
            this.assemblyNames = this.LoadProjectAssemblyNames();
        }

        private HashSet<string> LoadProjectAssemblyNames()
        {
            var asset = Resources.Load<OregoAssemblyConfig>(CONFIG_NAME);
            var projectNames = asset.assemblyNames.ToSet();
            Resources.UnloadAsset(asset);
            return projectNames;
        }

        #endregion

        #region LoadComponentTypes

        /// <summary>
        /// <para>Loads available component types from target assemblies in project.</para>
        /// </summary>
        /// <returns></returns>
        public override HashSet<Type> LoadComponentTypes()
        {
            var componentTypes = new HashSet<Type>();
            var currentDomain = AppDomain.CurrentDomain;
            var assemblies = currentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var assemblyName = assembly.GetName();
                var assemblyNameString = assemblyName.Name;
                if (!this.assemblyNames.Contains(assemblyNameString))
                {
                    continue;
                }

                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (this.MatchesComponentType(type))
                    {
                        componentTypes.Add(type);
                    }
                }
            }

            return componentTypes;
        }

        /// <summary>
        ///     <para>Filters a type for adding to pool.</para>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected virtual bool MatchesComponentType(Type type)
        {
            //Is IOregoComponent:
            if (!this.rootType.IsAssignableFrom(type))
            {
                return false;
            }

            //Is not abstract and class:
            if (type.IsAbstract || !type.IsClass)
            {
                return false;
            }

            return this.choiceCondition.MatchesComponentType(type);
        }

        #endregion
    }
}