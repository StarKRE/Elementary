using System.Collections.Generic;

namespace OregoFramework.Repo
{
    public interface IOregoStandardQuestRepository<T> :
        IOregoReadyDataRepository<IEnumerable<T>>
        where T : IOregoQuestData
    {
        T GetQuestData(string id);

        IEnumerable<T> GetQuestDataSet();

        void SetQuestData(T questData);

        void SetQuestDataSet(IEnumerable<T> questDataSet);
    }
}