using System;
using ElementaryFramework.Unit;

namespace ElementaryFramework.App
{
    public interface IUIStatefulResource : IResource
    {
        Type stateAdapterType { get; }
    }
}