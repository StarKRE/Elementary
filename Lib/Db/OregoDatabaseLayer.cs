using System.Collections.Generic;
using OregoFramework.App;
using OregoFramework.Core;

namespace OregoFramework.Db
{
    /// <summary>
    ///     <para>Default implementation of database layer.</para>
    ///     <para>This class type will added automatically by framework because
    ///     the class has attribute <see cref="OregoContext"/>.</para>
    ///     <para><see cref="OregoApplication"/> uses this database layer by default.</para>
    /// </summary>
    [OregoContext]
    public class OregoDatabaseLayer : OregoComponentLayer<IOregoDatabase>, IOregoDatabaseLayer
    {
        private IOregoApplication application;

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = Orego.GetObject<IOregoApplication>(nameof(IOregoApplication));
        }

        public T GetDatabase<T>() where T : IOregoDatabase
        {
            return (T) this[typeof(T)];
        }

        public IEnumerable<T> GetDatabases<T>() where T : IOregoDatabase
        {
            return this.GetComponents<T>();
        }

        protected TApplication GetApplication<TApplication>() where TApplication : IOregoApplication
        {
            return (TApplication) this.application;
        }
    }
}