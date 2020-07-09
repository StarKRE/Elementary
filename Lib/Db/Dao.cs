using OregoFramework.App;
using OregoFramework.Core;

namespace OregoFramework.Db
{
    /// <summary>
    ///     <para>Base abstract data access object implementation.</para>
    /// </summary>
    public abstract class Dao<T> : Element, IDao where T : IDatabase
    {
        protected T parentDatabase { get; private set; }

        private IApplication application;

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = Orego.GetObject<IApplication>(nameof(IApplication));
            var databaseLayer = this.application.GetDatabaseLayer<IDatabaseLayer>();
            this.parentDatabase = databaseLayer.GetDatabase<T>();
        }

        protected TApplication GetApplication<TApplication>() where TApplication : IApplication
        {
            return (TApplication) this.application;
        }
    }
}