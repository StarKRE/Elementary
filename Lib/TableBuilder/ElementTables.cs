using System;
using System.Collections.Generic;
using System.Text;

namespace Elementary
{
    /// <summary>
    ///     <para>Keeps two tables with type hierarchy: child and parent.</para>
    /// </summary>
    public sealed class ElementTables
    {
        public Dictionary<Type, HashSet<Type>> ChildTable { get; }

        public Dictionary<Type, HashSet<Type>> ParentTable { get; }

        public ElementTables()
        {
            this.ChildTable = new Dictionary<Type, HashSet<Type>>();
            this.ParentTable = new Dictionary<Type, HashSet<Type>>();
        }

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