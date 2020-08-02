using System;
using System.Collections.Generic;
using System.Reflection;
using ElementaryFramework.Util;
using UnityEngine;

namespace ElementaryFramework.Core
{
    public static class ElementTypeLoader
    {
        #region Const

        public const string CONFIG_NAME = "AssemblyConfig";

        private static readonly Type rootType = typeof(IElement);

        #endregion

        #region LoadTypes

        public static Dictionary<Type, HashSet<Type>> LoadTypeTable()
        {
            var typeTable = new Dictionary<Type, HashSet<Type>>();
            var assemblyNames = LoadProjectAssemblyNames();
            var currentDomain = AppDomain.CurrentDomain;
            var assemblies = currentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var assemblyName = assembly.GetName();
                var assemblyNameString = assemblyName.Name;
                if (!assemblyNames.Contains(assemblyNameString))
                {
                    continue;
                }

                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    TryLoadType(typeTable, type);
                }
            }

            return typeTable;
        }

        private static HashSet<string> LoadProjectAssemblyNames()
        {
            var asset = Resources.Load<AssemblyConfig>(CONFIG_NAME);
            var projectNames = asset.assemblyNames.ToSet();
            return projectNames;
        }

        private static void TryLoadType(Dictionary<Type, HashSet<Type>> typeTable, Type type)
        {
            //Is IElement:
            if (!rootType.IsAssignableFrom(type))
            {
                return;
            }

            //Is not abstract and class:
            if (type.IsAbstract || !type.IsClass)
            {
                return;
            }

            var attribute = type.GetCustomAttribute<Using>();
            if (attribute == null)
            {
                return;
            }

            var templateTypes = new List<Type>();
            var parentType = type.BaseType;
            while (!ReferenceEquals(parentType, null))
            {
                templateTypes.Add(parentType);
                parentType = parentType.BaseType;
            }
            
            templateTypes.AddRange(type.GetInterfaces());
            foreach (var templateType in templateTypes)
            {
                if (!typeTable.TryGetValue(templateType, out var implTypeSet))
                {
                    implTypeSet = new HashSet<Type>();
                    typeTable.Add(templateType, implTypeSet);
                }

                implTypeSet.Add(type);
            }
        }

        #endregion
    }
}