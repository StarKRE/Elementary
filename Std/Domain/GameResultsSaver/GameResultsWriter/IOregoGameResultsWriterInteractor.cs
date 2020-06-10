using System.Collections;
using OregoFramework.Domain;
using OregoFramework.Game;

namespace OregoFramework.Domain
{
    public interface IOregoGameResultsWriterInteractor : IOregoInteractor
    {
        IEnumerator OnWriteGameResults(object sender, IOregoGameContext gameContext);
    }
}