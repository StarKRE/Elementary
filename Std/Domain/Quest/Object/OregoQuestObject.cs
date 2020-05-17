using OregoFramework.Game;
using OregoFramework.Util;

namespace OregoFramework.Domain
{
    public abstract class OregoQuestObject :
        ComposableObject<IOregoQuestInfo, IOregoQuestObjectState>
    {
        protected OregoQuestObject(IOregoQuestInfo info, IOregoQuestObjectState state) :
            base(info, state)
        {
        }

        public abstract bool IsCompleted();
    }
}