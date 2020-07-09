using System.Collections;
using OregoFramework.Core;

namespace OregoFramework.Tools
{
    public interface IContentSection : IElement
    {
        IEnumerator LoadResources();
    }
}