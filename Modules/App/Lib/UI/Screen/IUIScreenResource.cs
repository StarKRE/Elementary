using System;
using ElementaryFramework.Unit;

namespace ElementaryFramework.App
{
    public interface IUIScreenResource : IResource
    {
        Type screenType { get; }
    }
}