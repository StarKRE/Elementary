using System.Collections.Generic;
using OregoFramework.App;
using OregoFramework.Core;

namespace OregoFramework.Db
{
    /// <summary>
    ///     <para>Default implementation of database layer.</para>
    ///     <para>This class type will added automatically by framework because
    ///     the class has attribute <see cref="OregoContext"/>.</para>
    ///     <para><see cref="Application"/> uses this database layer by default.</para>
    /// </summary>
    [OregoContext]
    public class DatabaseLayer : ElementLayer<IDatabase>, IDatabaseLayer
    {
        private IApplication application;

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = Orego.GetObject<IApplication>(nameof(IApplication));
        }

        public T GetDatabase<T>() where T : IDatabase
        {
            return this.GetElement<T>();
        }

        public IEnumerable<T> GetDatabases<T>() where T : IDatabase
        {
            return this.GetElements<T>();
        }

        protected TApplication GetApplication<TApplication>() where TApplication : IApplication
        {
            return (TApplication) this.application;
        }
    }
}