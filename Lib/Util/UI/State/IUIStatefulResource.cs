using System;
using OregoFramework.Tool;

namespace OregoFramework.UI
{
    public interface IUIStatefulResource : IOregoResource
    {
        Type stateAdapterType { get; }
    }
}