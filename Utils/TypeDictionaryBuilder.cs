using System;
using System.Collections.Generic;

namespace Elementary
{
    /// <summary>
    ///     <para>Builds an inheritance dictionary: abstact type vs implementation types.</para>
    /// </summary>
    public interface ITypeDictionaryBuilder
    {
        /// <summary>
        ///     <para>Builds an element type dictionary.</para>
        /// </summary>
        Dictionary<Type, HashSet<Type>> Build();
    }
    
    /// <inheritdoc cref="ITypeDictionaryBuilder"/>
    public class TypeDictionaryBuilder : ITypeDictionaryBuilder
    {
        private static readonly Type elementType = typeof(IElement);

        private static readonly Type usingType = typeof(Using);

        private static readonly Type objectType = typeof(object);

        /// <inheritdoc cref="ITypeDictionaryBuilder"/>
        public Dictionary<Type, HashSet<Type>> Build()
        {
            var inheritanceTable = new Dictionary<Type, HashSet<Type>>();
            var currentDomain = AppDomain.CurrentDomain;
            var assemblies = currentDomain.GetAssemblies();
            var availableAssemblySet = this.ProvideAssemblyNames();
            foreach (var assembly in assemblies)
            {
                var assemblyName = assembly.GetName().Name;
                if (!availableAssemblySet.Contains(assemblyName))
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

        /// <summary>
        ///     <para>Checks type to add it into inheritance dictionary.</para>
        /// </summary>
        /// <param name="type">Possible element type.</param>
        protected virtual bool MatchesType(Type type)
        {
            const int one = 1;
            return type.IsClass &&
                   !type.IsAbstract &&
                   type.GetCustomAttributes(usingType, true).Length == one &&
                   elementType.IsAssignableFrom(type);
        }

        private void TryRegisterType(Dictionary<Type, HashSet<Type>> table, Type type)
        {
            if (table.ContainsKey(type))
            {
                return;
            }

            if (!this.MatchesType(type))
            {
                return;
            }

            this.AddSelfType(table, type);
            this.AddInterfaceTypes(type, table);
            this.AddBaseTypes(type, table);
        }

        private void AddSelfType(Dictionary<Type, HashSet<Type>> table, Type type)
        {
            HashSet<Type> childTypes;
            if (!table.TryGetValue(type, out childTypes))
            {
                childTypes = new HashSet<Type>();
                table.Add(type, childTypes);
            }

            childTypes.Add(type);
        }

        private void AddInterfaceTypes(Type type, Dictionary<Type, HashSet<Type>> table)
        {
            var interfaceTypes = type.GetInterfaces();
            foreach (var interfaceType in interfaceTypes)
            {
                HashSet<Type> derivedTypes;
                if (!table.TryGetValue(interfaceType, out derivedTypes))
                {
                    derivedTypes = new HashSet<Type>();
                    table.Add(interfaceType, derivedTypes);
                }

                derivedTypes.Add(type);
            }
        }

        private void AddBaseTypes(Type type, Dictionary<Type, HashSet<Type>> table)
        {
            var baseType = type.BaseType;
            var derivedTypes = new HashSet<Type>
            {
                type
            };
            while (!ReferenceEquals(baseType, null) && !ReferenceEquals(baseType, objectType))
            {
                HashSet<Type> baseDerivedTypes;
                if (!table.TryGetValue(baseType, out baseDerivedTypes))
                {
                    baseDerivedTypes = new HashSet<Type>();
                    table.Add(baseType, baseDerivedTypes);
                }

                baseDerivedTypes.UnionWith(derivedTypes);
                if (this.MatchesType(baseType))
                {
                    derivedTypes.Add(baseType);
                }

                baseType = baseType.BaseType;
            }
        }

        /// <summary>
        ///     <para>Available assembly scopes of element types.</para>
        /// </summary>
        protected virtual HashSet<string> ProvideAssemblyNames()
        {
            return new HashSet<string>
            {
                "Assembly-CSharp-firstpass",
                "Assembly-CSharp"
            };
        }
    }
}
