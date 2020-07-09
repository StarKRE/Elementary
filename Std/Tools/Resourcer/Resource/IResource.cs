using OregoFramework.Core;

namespace OregoFramework.Tool
{
    public interface IResource : IElement
    {
        string path { get; }
    }
}