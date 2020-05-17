using OregoFramework.Util;

namespace OregoFramework.Domain
{
    public abstract class OregoDomainQuestInspector : OregoDomainComponent, IQuestInspector
    {
        public abstract void CheckQuests();
    }
}