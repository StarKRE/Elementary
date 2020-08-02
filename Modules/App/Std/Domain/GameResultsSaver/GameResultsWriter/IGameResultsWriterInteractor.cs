using System.Collections;
using ElementaryFramework.Game;
using ElementaryFramework.App;

namespace ElementaryFramework.App
{
    public interface IGameResultsWriterInteractor : IInteractor
    {
        IEnumerator OnWriteGameResults(object sender, IGameContext gameContext);
    }
}