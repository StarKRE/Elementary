using System.Collections;
using OregoFramework.Core;

namespace OregoFramework.Tools
{
    public abstract class OregoContentSection : OregoComponent, IOregoContentSection
    {
        public abstract IEnumerator LoadResources();
    }
}