using OregoFramework.App;
using OregoFramework.Core;

namespace OregoFramework.Db
{
    /// <summary>
    ///     <para>Base abstract data access object implementation.</para>
    /// </summary>
    public abstract class OregoDao<T> : OregoComponent, IOregoDao where T : IOregoDatabase
    {
        protected T parentDatabase { get; private set; }

        private IOregoApplication application;

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = Orego.GetObject<IOregoApplication>(nameof(IOregoApplication));
            var databaseLayer = this.application.GetDatabaseLayer<IOregoDatabaseLayer>();
            this.parentDatabase = databaseLayer.GetDatabase<T>();
        }

        protected TApplication GetApplication<TApplication>() where TApplication : IOregoApplication
        {
            return (TApplication) this.application;
        }
    }
}