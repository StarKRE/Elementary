using System.Collections.Generic;
using ElementaryFramework.Core;

namespace ElementaryFramework.App
{
    /// <summary>
    ///     <para>Default implementation of database layer.</para>
    ///     <para>This class type will added automatically by framework because
    ///     the class has attribute <see cref="Using"/>.</para>
    ///     <para><see cref="Application"/> uses this database layer by default.</para>
    /// </summary>
    [Using]
    public class DatabaseLayer : ElementLayer<IDatabase>, IDatabaseLayer
    {
        protected IApplication application { get; private set; }

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = this.GetRoot<IApplication>();
        }

        public T GetDatabase<T>() where T : IDatabase
        {
            return this.GetElement<T>();
        }

        public IEnumerable<T> GetDatabases<T>() where T : IDatabase
        {
            return this.GetElements<T>();
        }
    }
}