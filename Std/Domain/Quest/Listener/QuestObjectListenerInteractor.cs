namespace OregoFramework.Domain
{
    public abstract class QuestObjectListenerInteractor<T> : OregoDomainComponent, IQuestObjectListenerInteractor
        where T : OregoQuestObject
    {
        protected abstract IOregoQuestObjectSourceInteractor<T> questObjectSourceInteractor { get; set; }
        
        #region OnReady

        public override void OnReady()
        {
            base.OnReady();
            this.questObjectSourceInteractor.OnObjectChangedEvent += this.OnQuestObjectChanged;
        }

        #endregion

        #region OnStop

        public override void OnStop()
        {
            base.OnStop();
            this.questObjectSourceInteractor.OnObjectChangedEvent -= this.OnQuestObjectChanged;
        }

        #endregion

        #region QuestObjectInteractorEvents

        public void OnQuestObjectChanged(object sender, OregoQuestObject questObject)
        {
            this.OnQuestChanged(sender, (T) questObject);
        }

        protected virtual void OnQuestChanged(object sender, T questObject)
        {
        }

        #endregion
    }
}