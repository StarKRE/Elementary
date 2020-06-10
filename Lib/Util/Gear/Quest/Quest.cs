namespace OregoFramework.Util
{
    public abstract class Quest : AutoScriptableObject, IQuest
    {
        public abstract string title { get; }
    }
}