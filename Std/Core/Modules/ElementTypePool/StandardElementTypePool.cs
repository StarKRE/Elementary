using System;
using System.Collections.Generic;
using OregoFramework.Util;
using UnityEngine;

namespace OregoFramework.Core
{
    /// <summary>
    ///     <para>Standard implementation of element type pool.</para>
    /// </summary>
    public class StandardElementTypePool : ElementTypePool
    {
        #region Const

        public const string CONFIG_NAME = "AssemblyConfig";

        #endregion

        protected virtual IElementChoiceCondition choiceCondition { get; } =
            new EnvironmentElementChoiceCondition<OregoContext.IEnvironment>();

        protected virtual Type rootType { get; } =
            typeof(IElement);

        protected HashSet<string> assemblyNames { get; private set; }

        #region Initialize

        public override void OnProvideCore(IModularCore core)
        {
            base.OnProvideCore(core);
            this.assemblyNames = this.LoadProjectAssemblyNames();
        }

        private HashSet<string> LoadProjectAssemblyNames()
        {
            var asset = Resources.Load<AssemblyConfig>(CONFIG_NAME);
            var projectNames = asset.assemblyNames.ToSet();
            Resources.UnloadAsset(asset);
            return projectNames;
        }

        #endregion

        #region LoadElementTypes

        /// <summary>
        /// <para>Loads available element types from target assemblies in project.</para>
        /// </summary>
        /// <returns></returns>
        public override HashSet<Type> LoadElementTypes()
        {
            var elementTypes = new HashSet<Type>();
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
                    if (this.MatchesElementType(type))
                    {
                        elementTypes.Add(type);
                    }
                }
            }

            return elementTypes;
        }

        /// <summary>
        ///     <para>Filters a type for adding to pool.</para>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected virtual bool MatchesElementType(Type type)
        {
            //Is IElement:
            if (!this.rootType.IsAssignableFrom(type))
            {
                return false;
            }

            //Is not abstract and class:
            if (type.IsAbstract || !type.IsClass)
            {
                return false;
            }

            return this.choiceCondition.MatchesElementType(type);
        }

        #endregion
    }
}