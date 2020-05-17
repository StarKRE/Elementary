using System;
using System.Collections.Generic;
using OregoFramework.Util;

namespace OregoFramework.Domain
{
    public abstract class OregoQuestInspectSystemInteractor : OregoInteractor, IQuestInspectSystem
    {
        private readonly Dictionary<Type, IQuestInspector> inspectorMap;

        protected OregoQuestInspectSystemInteractor()
        {
            this.inspectorMap = new Dictionary<Type, IQuestInspector>();
        }

        #region OnCreate

        public override void OnCreate()
        {
            base.OnCreate();
            var inspectors = this.LoadInspectors();
            foreach (var inspector in inspectors)
            {
                this.inspectorMap.AddByType(inspector);
            }
        }

        protected abstract IEnumerable<IQuestInspector> LoadInspectors();

        #endregion

        public IEnumerable<T> GetInspectors<T>() where T : IQuestInspector
        {
            return this.inspectorMap.FindAll<T, IQuestInspector>();
        }

        public T GetInspector<T>() where T : IQuestInspector
        {
            return this.inspectorMap.Find<T, IQuestInspector>();
        }
    }
}