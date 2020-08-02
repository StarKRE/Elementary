using System;
using System.Collections;
using System.Collections.Generic;
using ElementaryFramework.Game;
using ElementaryFramework.App;

namespace ElementaryFramework.App
{
    public abstract class GameResultsSaverInteractor : Interactor
    {
        #region Event

        public event Action<object, IGameContext> OnGameResultsSavedEvent;

        #endregion
        
        private IEnumerable<IGameResultsWriterInteractor> gameWriterInteractors;
        
        public override void OnPrepare()
        {
            base.OnPrepare();
            this.gameWriterInteractors = this.GetInteractors<IGameResultsWriterInteractor>();
        }

        public IEnumerator SaveGameResults(object sender, IGameContext gameContext)
        {
            foreach (var gameWriterInteractor in this.gameWriterInteractors)
            {
                yield return gameWriterInteractor.OnWriteGameResults(sender, gameContext);
            }
            
            this.OnGameResultsSavedEvent?.Invoke(sender, gameContext);
        }
    }
}