using System.Collections.Generic;
using System.Linq;
using ElementaryFramework.Core;

namespace ElementaryFramework.App
{
    /// <summary>
    ///     <para>Base abstract implementation of client interface.</para>
    /// </summary>
    /// <typeparam name="T">Requred caller type.</typeparam>
    public abstract class Client<T> : ElementLayer<T>, IClient where T : ICaller
    {
        public TCaller GetCaller<TCaller>() where TCaller : ICaller
        {
            return (TCaller) (ICaller) this[typeof(TCaller)];
        }

        public IEnumerable<TCaller> GetCallers<TCaller>() where TCaller : ICaller
        {
            return this.allElements.OfType<TCaller>();
        }
    }
}