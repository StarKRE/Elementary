using System.Collections.Generic;
using System.Linq;
using ElementaryFramework.Core;

namespace ElementaryFramework.App
{
    /// <summary>
    ///     <para>Base abstract database implementation.</para>
    /// </summary>
    /// <typeparam name="T">Interface type of dao.</typeparam>
    public abstract class Database<T> : ElementLayer<T>, IDatabase where T : IDao
    {
        protected IApplication application { get; private set; }

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = this.GetRoot<IApplication>();
        }

        public TDao GetDao<TDao>() where TDao : IDao
        {
            return (TDao) (IDao) this[typeof(TDao)];
        }

        public IEnumerable<TDao> GetDaoSet<TDao>() where TDao : IDao
        {
            return this.allElements.OfType<TDao>();
        }
    }
}