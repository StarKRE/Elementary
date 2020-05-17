using OregoFramework.Core;

namespace OregoFramework.Tool
{
    public interface IOregoResource : IOregoComponent
    {
        string path { get; }
    }
}