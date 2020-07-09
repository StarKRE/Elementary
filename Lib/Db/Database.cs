using System.Collections.Generic;
using System.Linq;
using OregoFramework.App;
using OregoFramework.Core;

namespace OregoFramework.Db
{
    /// <summary>
    ///     <para>Base abstract database implementation.</para>
    /// </summary>
    /// <typeparam name="T">Interface type of dao.</typeparam>
    public abstract class Database<T> : ElementLayer<T>, IDatabase where T : IDao
    {
        private IApplication application;

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = Orego.GetObject<IApplication>(nameof(IApplication));
        }

        public TDao GetDao<TDao>() where TDao : IDao
        {
            return (TDao) (IDao) this[typeof(TDao)];
        }

        public IEnumerable<TDao> GetDaoSet<TDao>() where TDao : IDao
        {
            return this.allElements.OfType<TDao>();
        }

        protected TApplication GetApplication<TApplication>() where TApplication : IApplication
        {
            return (TApplication) this.application;
        }
    }
}