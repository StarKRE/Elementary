using System.Collections;
using OregoFramework.Domain;
using OregoFramework.Game;

namespace OregoFramework.Domain
{
    public interface IGameResultsWriterInteractor : IInteractor
    {
        IEnumerator OnWriteGameResults(object sender, IGameContext gameContext);
    }
}