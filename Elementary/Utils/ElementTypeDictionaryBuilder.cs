using System;
using System.Collections.Generic;

namespace Elementary
{
    /// <summary>
    ///     <para>Builds an inheritance dictionary: interface vs specific type.</para>
    /// </summary>
    public class ElementTypeDictionaryBuilder
    {
        private static readonly Type elementType = typeof(IElement);

        private static readonly Type usingType = typeof(Using);

        private static readonly Type objectType = typeof(object);

        /// <summary>
        ///     <para>Finds available element types only in the selected assemblies.</para>
        /// </summary>
        protected virtual HashSet<string> RequiredAssemblies { get; } = new HashSet<string>
        {
            "Assembly-CSharp-firstpass",
            "Assembly-CSharp"
        };

        public Dictionary<Type, HashSet<Type>> Build()
        {
            var inheritanceTable = new Dictionary<Type, HashSet<Type>>();
            var currentDomain = AppDomain.CurrentDomain;
            var assemblies = currentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var assemblyName = assembly.GetName();
                var assemblyNameString = assemblyName.Name;
                if (!this.RequiredAssemblies.Contains(assemblyNameString))
                {
                    continue;
                }

                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    this.TryRegisterType(inheritanceTable, type);
                }
            }

            return inheritanceTable;
        }

        protected virtual bool IsSpecificType(Type type)
        {
            const int one = 1;
            return type.IsClass &&
                   !type.IsAbstract &&
                   type.GetCustomAttributes(usingType, true).Length == one &&
                   elementType.IsAssignableFrom(type);
        }

        private void TryRegisterType(Dictionary<Type, HashSet<Type>> table, Type targetType)
        {
            if (table.ContainsKey(targetType))
            {
                return;
            }

            if (!this.IsSpecificType(targetType))
            {
                return;
            }

            this.AddInterfaceTypes(targetType, table);
            this.AddBaseTypes(targetType, table);
        }

        private void AddInterfaceTypes(Type targetType, Dictionary<Type, HashSet<Type>> table)
        {
            var types = targetType.GetInterfaces();
            foreach (var type in types)
            {
                if (!table.TryGetValue(type, out var childTypes))
                {
                    childTypes = new HashSet<Type>();
                    table.Add(type, childTypes);
                }

                childTypes.Add(targetType);
            }
        }

        private void AddBaseTypes(Type targetType, Dictionary<Type, HashSet<Type>> table)
        {
            var baseType = targetType.BaseType;
            var derivedTypes = new HashSet<Type>
            {
                targetType
            };
            while (!ReferenceEquals(baseType, objectType))
            {
                if (!table.TryGetValue(baseType!, out var baseDerivedTypes))
                {
                    baseDerivedTypes = new HashSet<Type>();
                    table.Add(baseType, baseDerivedTypes);
                }

                baseDerivedTypes.UnionWith(derivedTypes);
                if (this.IsSpecificType(baseType))
                {
                    derivedTypes.Add(baseType);
                }

                baseType = baseType.BaseType;
            }
        }
    }
}