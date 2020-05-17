using System;
using OregoFramework.Tool;

namespace OregoFramework.UI
{
    public interface IOregoUIScreenResource : IOregoResource
    {
        Type screenType { get; }
    }
}