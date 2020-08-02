using ElementaryFramework.Core;

namespace ElementaryFramework.App
{
    /// <summary>
    ///     <para>Base abstract implementation of caller interface.</para>
    /// </summary>
    public abstract class Caller<T> : Element, ICaller where T : IClient
    {
        protected IApplication application { get; private set; }

        protected T parentClient { get; private set; }

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = this.GetRoot<IApplication>();
            var clientLayer = this.application.clientLayer;
            this.parentClient = clientLayer.GetClient<T>();
        }
    }
}