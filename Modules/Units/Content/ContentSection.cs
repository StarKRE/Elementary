using System.Collections;
using ElementaryFramework.Core;

namespace ElementaryFramework.Unit
{
    public abstract class ContentSection : Element, IContentSection
    {
        public abstract IEnumerator LoadResources();
    }
}