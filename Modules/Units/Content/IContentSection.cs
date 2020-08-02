using System.Collections;
using ElementaryFramework.Core;

namespace ElementaryFramework.Unit
{
    public interface IContentSection : IElement
    {
        IEnumerator LoadResources();
    }
}