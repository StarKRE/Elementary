using System.Collections;
using OregoFramework.Domain;
using OregoFramework.Game;

namespace CatchACockRoach.Domain
{
    public interface IOregoGameResultsWriterInteractor : IOregoInteractor
    {
        IEnumerator OnWriteGameResults(object sender, IOregoGameSession gameSession);
    }
}