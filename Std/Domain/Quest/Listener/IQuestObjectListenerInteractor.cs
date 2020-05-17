namespace OregoFramework.Domain
{
    public interface IQuestObjectListenerInteractor : IOregoInteractor
    {
        void OnQuestObjectChanged(object sender, OregoQuestObject questObject);
    }
}