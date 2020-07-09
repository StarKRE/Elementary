using System;
using OregoFramework.Tool;

namespace OregoFramework.UI
{
    public interface IUIStatefulResource : IResource
    {
        Type stateAdapterType { get; }
    }
}