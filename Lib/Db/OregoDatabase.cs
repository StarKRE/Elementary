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
    public abstract class OregoDatabase<T> : OregoComponentLayer<T>, IOregoDatabase where T : IOregoDao
    {
        private IOregoApplication application;

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = Orego.GetObject<IOregoApplication>(nameof(IOregoApplication));
        }

        public TDao GetDao<TDao>() where TDao : IOregoDao
        {
            return (TDao) (IOregoDao) this[typeof(TDao)];
        }

        public IEnumerable<TDao> GetDaoSet<TDao>() where TDao : IOregoDao
        {
            return this.allComponents.OfType<TDao>();
        }

        protected TApplication GetApplication<TApplication>() where TApplication : IOregoApplication
        {
            return (TApplication) this.application;
        }
    }
}