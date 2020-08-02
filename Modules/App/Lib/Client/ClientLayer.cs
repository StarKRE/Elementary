using System.Collections.Generic;
using ElementaryFramework.Core;

namespace ElementaryFramework.App
{
    /// <summary>
    ///     <para>Base implementation of client layer interface.</para>
    ///     <para>This class type will added automatically by framework because
    ///     the class has attribute <see cref="Using"/>.</para>
    ///     <para><see cref="Application"/> uses this client layer by default.</para>
    /// </summary>
    [Using]
    public class ClientLayer : ElementLayer<IClient>, IClientLayer
    {
        public T GetClient<T>() where T : IClient
        {
            return this.GetElement<T>();
        }

        public IEnumerable<T> GetClients<T>() where T : IClient
        {
            return this.GetElements<T>();
        }
    }
}