using System;
using System.Collections.Generic;
using System.Text;

namespace Elementary
{
    /// <summary>
    ///     <para>A table wrapper. Keeps two tables: child and parent.</para>
    ///     <para>They will be used to create instances of elements.</para>
    /// </summary>
    public sealed class ElementTables
    {
        /// <summary>
        ///     <para>Child table. Keeps type vs child types.</para>
        /// </summary>
        public Dictionary<Type, HashSet<Type>> ChildTable { get; }

        /// <summary>
        ///     <para>Parent table. Keeps type vs parent types.</para>
        /// </summary>
        public Dictionary<Type, HashSet<Type>> ParentTable { get; }

        public ElementTables()
        {
            this.ChildTable = new Dictionary<Type, HashSet<Type>>();
            this.ParentTable = new Dictionary<Type, HashSet<Type>>();
        }

        /// <summary>
        ///     <para>Use this method to print the tables into console.</para>
        /// </summary>
        /// 
        /// <returns>String</returns>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            AppendTable(stringBuilder, this.ParentTable, "Parent table");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine();
            AppendTable(stringBuilder, this.ChildTable, "Child table");
            return stringBuilder.ToString();
        }

        private static void AppendTable(
            StringBuilder stringBuilder,
            Dictionary<Type, HashSet<Type>> table,
            string tableName
        )
        {
            stringBuilder.AppendLine($"{tableName}: ");
            foreach (var pair in table)
            {
                stringBuilder.Append($"{pair.Key} ->");
                foreach (var type in pair.Value)
                {
                    stringBuilder.Append($"{type.Name} ");
                }

                stringBuilder.AppendLine();
            }
        }
    }
}