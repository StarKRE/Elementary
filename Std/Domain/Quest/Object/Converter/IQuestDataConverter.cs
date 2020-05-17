using System;
using OregoFramework.Repo;

namespace OregoFramework.Domain
{
    public interface IQuestDataConverter
    {
        Type questType { get; }
        
        IOregoQuestObjectState ConvertToState(IOregoQuestData questData);

        IOregoQuestData ConvertToData(IOregoQuestObjectState questState);
    }
}