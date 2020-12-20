using System;
using System.Collections.Generic;

namespace Elementary
{
    using ChildTable = Dictionary<Type, HashSet<Type>>;
    using ParentTable = Dictionary<Type, HashSet<Type>>;

    /// <inheritdoc cref="IElementSheetBuilder"/>
    public class ElementSheetBuilder : IElementSheetBuilder
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

        /// <inheritdoc cref="IElementSheetBuilder.Build"/>
        public ElementSheet Build()
        {
            var elementTables = new ElementSheet();
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
                    this.AssemblyType(elementTables, type);
                }
            }

            return elementTables;
        }

        protected virtual bool IsSpecificType(Type type)
        {
            return type.IsClass &&
                   !type.IsAbstract &&
                   type.GetCustomAttributes(usingType, true).Length == 1 &&
                   elementType.IsAssignableFrom(type);
        }

        private void AssemblyType(ElementSheet sheet, Type targetType)
        {
            var childTable = sheet.ChildTable;
            if (childTable.ContainsKey(targetType))
            {
                return;
            }

            if (!this.IsSpecificType(targetType))
            {
                return;
            }

            this.WireInterfaces(targetType, childTable);
            this.WireBaseTypes(sheet, targetType);
        }

        private void WireInterfaces(Type targetType, ChildTable childTable)
        {
            var interfaces = targetType.GetInterfaces();
            foreach (var @interface in interfaces)
            {
                if (!childTable.TryGetValue(@interface, out var childTypes))
                {
                    childTypes = new HashSet<Type>();
                    childTable.Add(@interface, childTypes);
                }

                childTypes.Add(targetType);
            }
        }

        private void WireBaseTypes(ElementSheet sheet, Type targetType)
        {
            var parentTable = sheet.ParentTable;
            var childTable = sheet.ChildTable;
            var baseType = targetType.BaseType;
            var targetChildTypes = new HashSet<Type>
            {
                targetType
            };
            while (!ReferenceEquals(baseType, objectType))
            {
                if (!childTable.TryGetValue(baseType!, out var baseChildTypes))
                {
                    baseChildTypes = new HashSet<Type>();
                    childTable.Add(baseType, baseChildTypes);
                }

                baseChildTypes.UnionWith(targetChildTypes);
                foreach (var targetChildType in targetChildTypes)
                {
                    if (!parentTable.TryGetValue(targetChildType, out var baseParentTypes))
                    {
                        baseParentTypes = new HashSet<Type>();
                        parentTable.Add(targetChildType, baseParentTypes);
                    }

                    baseParentTypes.Add(baseType);
                }

                if (this.IsSpecificType(baseType))
                {
                    targetChildTypes.Add(baseType);
                }

                baseType = baseType.BaseType;
            }
        }
    }
}