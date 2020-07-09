using System;
using OregoFramework.Tool;

namespace OregoFramework.UI
{
    public interface IUIScreenResource : IResource
    {
        Type screenType { get; }
    }
}