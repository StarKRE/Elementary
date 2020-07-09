using System.Collections;
using OregoFramework.Core;

namespace OregoFramework.Tools
{
    public abstract class ContentSection : Element, IContentSection
    {
        public abstract IEnumerator LoadResources();
    }
}