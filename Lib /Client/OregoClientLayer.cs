using System.Collections.Generic;
using OregoFramework.Core;
using OregoFramework.App;

namespace OregoFramework.Client
{
    /// <summary>
    ///     <para>Base implementation of client layer interface.</para>
    ///     <para>This class type will added automatically by framework because
    ///     the class has attribute <see cref="OregoContext"/>.</para>
    ///     <para><see cref="OregoApplication"/> uses this client layer by default.</para>
    /// </summary>
    [OregoContext]
    public class OregoClientLayer : OregoComponentLayer<IOregoClient>, IOregoClientLayer
    {
        private IOregoApplication application;

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.application = Orego.GetObject<IOregoApplication>(nameof(IOregoApplication));
        }

        public T GetClient<T>() where T : IOregoClient
        {
            return (T) this[typeof(T)];
        }

        public IEnumerable<T> GetClients<T>() where T : IOregoClient
        {
            return this.GetComponents<T>();
        }

        protected T GetApplication<T>() where T : IOregoApplication
        {
            return (T) this.application;
        }
    }
}