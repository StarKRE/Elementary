using ElementaryFramework.Core;

namespace ElementaryFramework.App
{
    /// <summary>
    ///     <para>Base abstract data access object implementation.</para>
    /// </summary>
    public abstract class Dao<T> : Element, IDao where T : IDatabase
    {
        protected IApplication application { get; private set; }
        
        protected T parentDatabase { get; private set; }
     
        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = this.GetRoot<IApplication>();
            var databaseLayer = this.application.databaseLayer;
            this.parentDatabase = databaseLayer.GetDatabase<T>();
        }
    }
}