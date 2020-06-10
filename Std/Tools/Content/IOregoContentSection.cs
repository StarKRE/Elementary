using System.Collections;
using OregoFramework.Core;

namespace OregoFramework.Tools
{
    public interface IOregoContentSection : IOregoComponent
    {
        IEnumerator LoadResources();
    }
}