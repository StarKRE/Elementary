namespace OregoFramework.Domain
{
    public interface IOregoQuestObjectSourceInteractor<T> : 
        IOregoObjectSourceMapInteractor<string, T>,
        IOregoObjectDataInitializerInteractor
        where T : OregoQuestObject
    {
    }
}