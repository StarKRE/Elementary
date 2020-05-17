using System;
using OregoFramework.Game;
using OregoFramework.Repo;

namespace OregoFramework.Domain
{
    public abstract class OregoMutableQuestObjectSourceInteractor<TQuestObject, TQuestData> :
        OregoQuestObjectSourceInteractor<TQuestObject, TQuestData>,
        IOregoMutableObjectSourceMapInteractor<string, TQuestObject>
        where TQuestObject : OregoQuestObject
        where TQuestData : IOregoQuestData
    {
        #region Event

        public event Action<object, TQuestObject> OnObjectAddedEvent;

        public event Action<object, TQuestObject> OnObjectRemovedEvent;

        #endregion

        public void NotifyAboutObjectAdded(object sender, TQuestObject questObject)
        {
            var questid = questObject.GetInfo<IOregoQuestInfo>().id;
            this.objectMap[questid] = questObject;
            this.OnObjectAddedEvent?.Invoke(sender, questObject);
        }

        public void NotifyAboutObjectRemoved(object sender, TQuestObject questObject)
        {
            var questId = questObject.GetInfo<IOregoQuestInfo>().id;
            this.objectMap.Remove(questId);
            this.OnObjectRemovedEvent?.Invoke(sender, questObject);
        }
    }
}