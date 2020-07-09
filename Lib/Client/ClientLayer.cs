using System.Collections.Generic;
using OregoFramework.Core;
using OregoFramework.App;

namespace OregoFramework.Client
{
    /// <summary>
    ///     <para>Base implementation of client layer interface.</para>
    ///     <para>This class type will added automatically by framework because
    ///     the class has attribute <see cref="OregoContext"/>.</para>
    ///     <para><see cref="Application"/> uses this client layer by default.</para>
    /// </summary>
    [OregoContext]
    public class ClientLayer : ElementLayer<IClient>, IClientLayer
    {
        private IApplication application;

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = Orego.GetObject<IApplication>(nameof(IApplication));
        }

        public T GetClient<T>() where T : IClient
        {
            return this.GetElement<T>();
        }

        public IEnumerable<T> GetClients<T>() where T : IClient
        {
            return this.GetElements<T>();
        }

        protected T GetApplication<T>() where T : IApplication
        {
            return (T) this.application;
        }
    }
}