#if SQL

using System;
using System.Collections;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;
using OregoFramework.App;
using OregoFramework.Core;
using OregoFramework.Util;

namespace OregoFramework.Db
{
    public abstract class SqliteDao : Dao<SqliteDatabase>
    {
        #region Const

        private const string COMMA = ",";

        private const string OPENING_PARENTHESIS = "(";

        #endregion
        
        protected DbConnection connection
        {
            get { return this.parentDatabase.connection; }
        }

        public virtual IEnumerator OnConnect()
        {
            yield break;
        }

        #region Execute

        protected void Execute(string commandText, Action<DbCommand> func)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = commandText;
                func.Invoke(command);
            }
        }

        protected IEnumerator Execute(string commandText, Func<DbCommand, Task> asyncFunc)
        {
            var command = this.connection.CreateCommand();
            command.CommandText = commandText;
            yield return Continuation.Suspend(continuation =>
            {
                Task
                    .Run(() => asyncFunc.Invoke(command))
                    .ContinueWith(it => command.Dispose())
                    .ContinueWith(it => continuation.Continue());
            });
        }
        #endregion

        #region SerializeEntity

        protected string SerializeEntities<T>(T[] entities, Func<T, object[]> transformFunc)
        {
            var stringBuilder = new StringBuilder();
            var lastEntityIndex = entities.Length - Int.ONE;
            for (var i = Int.ZERO; i < lastEntityIndex; i++)
            {
                this.SerializeEntityInternal(transformFunc.Invoke(entities[i]), stringBuilder);
                stringBuilder.Append(COMMA);
            }

            this.SerializeEntityInternal(
                transformFunc.Invoke(entities[lastEntityIndex]),
                stringBuilder
            );
            return stringBuilder.ToString();
        }

        protected string SerializeEntity(object[] parameters)
        {
            var stringBuilder = new StringBuilder();
            this.SerializeEntityInternal(parameters, stringBuilder);
            return stringBuilder.ToString();
        }

        private void SerializeEntityInternal(object[] parameters, StringBuilder stringBuilder)
        {
            stringBuilder.Append(OPENING_PARENTHESIS);
            var lastIndex = parameters.Length - Int.ONE;
            for (var i = Int.ZERO; i < lastIndex; i++)
            {
                stringBuilder.Append($"'{parameters[i]}',");
            }

            stringBuilder.Append($"'{parameters[lastIndex]}')");
        }

        #endregion
    }
}

#endif