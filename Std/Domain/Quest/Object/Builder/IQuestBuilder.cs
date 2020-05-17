using System;
using OregoFramework.Game;

namespace OregoFramework.Domain
{
    public interface IQuestBuilder
    {
        Type questType { get; }
        
        bool CanBuildNewQuest();
        
        OregoQuestObject BuildNewQuest(IOregoQuestInfo info);

        OregoQuestObject BuildQuest(IOregoQuestInfo info, IOregoQuestObjectState state);
    }
}