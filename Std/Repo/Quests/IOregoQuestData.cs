using OregoFramework.Util;

namespace OregoFramework.Repo
{
    public interface IOregoQuestData : ICloneable<IOregoQuestData>
    {
        string id { get; set; }

        string json { get; set; }
    }
}