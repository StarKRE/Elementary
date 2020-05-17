using System;
using System.Collections.Generic;
using OregoFramework.Game;
using OregoFramework.Repo;

namespace OregoFramework.Domain
{
    public abstract class OregoQuestObjectSourceInteractor<TQuestObject, TQuestData> :
        OregoStandardObjectSourceMapInteractor<
            string, TQuestObject, IOregoStandardQuestRepository<TQuestData>, TQuestData
        >
        where TQuestObject : OregoQuestObject
        where TQuestData : IOregoQuestData
    {
        protected readonly Dictionary<Type, IQuestDataConverter> questDataConverterMap;

        protected readonly Dictionary<Type, IQuestBuilder> questBuilderMap;

        protected readonly Dictionary<string, IOregoQuestInfo> questInfoSet;

        protected OregoQuestObjectSourceInteractor()
        {
            this.questDataConverterMap = new Dictionary<Type, IQuestDataConverter>();
            this.questBuilderMap = new Dictionary<Type, IQuestBuilder>();
            this.questInfoSet = new Dictionary<string, IOregoQuestInfo>();
        }

        #region OnCreate

        public override void OnCreate()
        {
            base.OnCreate();
            var questInfoSet = this.LoadQuestInfoSet();
            foreach (var questInfo in questInfoSet)
            {
                var questId = questInfo.id;
                this.questInfoSet[questId] = questInfo;
            }

            var questDataConverters = this.LoadQuestDataConverters();
            foreach (var questDataConverter in questDataConverters)
            {
                var questType = questDataConverter.questType;
                this.questDataConverterMap[questType] = questDataConverter;
            }

            var questBuilders = this.LoadQuestBuilders();
            foreach (var questBuilder in questBuilders)
            {
                var questType = questBuilder.questType;
                this.questBuilderMap[questType] = questBuilder;
            }
        }

        protected abstract IEnumerable<IOregoQuestInfo> LoadQuestInfoSet();

        protected abstract IEnumerable<IQuestDataConverter> LoadQuestDataConverters();

        protected abstract IEnumerable<IQuestBuilder> LoadQuestBuilders();

        #endregion

        #region SetupQuests

        protected sealed override TQuestObject SetupObject(TQuestData questData)
        {
            var id = questData.id;
            var questType = questData.GetType();
            var questObjectBuilder = this.questDataConverterMap[questType];
            var questState = questObjectBuilder.ConvertToState(questData);
            var questInfo = this.questInfoSet[id];
            var questBuilder = this.questBuilderMap[questType];
            var quest = (TQuestObject) questBuilder.BuildQuest(questInfo, questState);
            return quest;
        }

        protected override string GetObjectId(TQuestObject tObject)
        {
            return tObject.GetInfo<IOregoQuestInfo>().id;
        }

        #endregion

        public TConverter GetDataConverter<TConverter>(Type questType)
            where TConverter : IQuestDataConverter
        {
            return (TConverter) this.questDataConverterMap[questType];
        }

        public TBuider GetQuestBuilder<TBuider>(Type questType) where TBuider : IQuestBuilder
        {
            return (TBuider) this.questBuilderMap[questType];
        }

        public TInfo GetQuestInfo<TInfo>(string id) where TInfo : IOregoQuestInfo
        {
            return (TInfo) this.questInfoSet[id];
        }
    }
}