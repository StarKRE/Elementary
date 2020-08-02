using ElementaryFramework.Core;

namespace ElementaryFramework.Unit
{
    public interface IResource : IElement
    {
        string path { get; }
    }
}