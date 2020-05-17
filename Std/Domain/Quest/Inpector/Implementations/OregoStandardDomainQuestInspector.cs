using System.Collections.Generic;
using System.Linq;
using OregoFramework.Game;

namespace OregoFramework.Domain
{
    public abstract class OregoStandardDomainQuestInspector<T> : OregoDomainQuestInspector where T : OregoQuestObject
    {
        protected readonly Dictionary<string, OregoQuestObject> inspectingQuestObjects;

        protected abstract IOregoQuestObjectSourceInteractor<T> objectSourceInteractor { get; set; }

        protected OregoStandardDomainQuestInspector()
        {
            this.inspectingQuestObjects = new Dictionary<string, OregoQuestObject>();
        }

        #region OnReady

        public override void OnReady()
        {
            base.OnReady();
            this.objectSourceInteractor.OnObjectDataInitializedEvent += this.OnQuestObjectsInitialized;
        }

        #endregion

        #region OnStop

        public override void OnStop()
        {
            base.OnStop();
            this.objectSourceInteractor.OnObjectDataInitializedEvent -= this.OnQuestObjectsInitialized;
        }

        #endregion

        #region CheckQuests

        public override void CheckQuests()
        {
            var inspectingQuestObjects = this.inspectingQuestObjects.Values.ToList();
            foreach (var inspectingQuestObject in inspectingQuestObjects)
            {
                this.CheckQuest(inspectingQuestObject);
            }
        }

        protected abstract void CheckQuest(OregoQuestObject inspectingQuestObject);

        #endregion

        #region InteractorEvents

        protected virtual void OnQuestObjectsInitialized(object sender)
        {
            var questObjects = this.FetchInspectingQuests();
            foreach (var questObject in questObjects)
            {
                this.StartInspect(questObject);
            }

            this.CheckQuests();
        }

        protected abstract IEnumerable<OregoQuestObject> FetchInspectingQuests();

        protected void StartInspect(OregoQuestObject questObject)
        {
            var questId = questObject.GetInfo<IOregoQuestInfo>().id;
            this.inspectingQuestObjects[questId] = questObject;
            this.OnStartInspect(questObject);
        }

        protected abstract void OnStartInspect(OregoQuestObject questObject);

        #endregion
    }
}