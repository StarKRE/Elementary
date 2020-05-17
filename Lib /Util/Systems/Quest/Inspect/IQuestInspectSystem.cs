using System.Collections.Generic;

namespace OregoFramework.Util
{
    public interface IQuestInspectSystem
    {
        IEnumerable<T> GetInspectors<T>() where T : IQuestInspector;
        
        T GetInspector<T>() where T : IQuestInspector;
    }
}