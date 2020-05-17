using System;
using System.Collections;
using System.Collections.Generic;
using OregoFramework.Domain;
using OregoFramework.Game;

namespace CatchACockRoach.Domain
{
    public abstract class OregoGameResultsSaverInteractor : OregoInteractor
    {
        #region Event

        public event Action<object, IOregoGameSession> OnGameResultsSavedEvent;

        #endregion
        
        private IEnumerable<IOregoGameResultsWriterInteractor> gameWriterInteractors;
        
        public override void OnPrepare()
        {
            base.OnPrepare();
            this.gameWriterInteractors = this.GetInteractors<IOregoGameResultsWriterInteractor>();
        }

        public IEnumerator SaveGameResults(object sender, IOregoGameSession gameSession)
        {
            foreach (var gameWriterInteractor in this.gameWriterInteractors)
            {
                yield return gameWriterInteractor.OnWriteGameResults(sender, gameSession);
            }
            
            this.OnGameResultsSavedEvent?.Invoke(sender, gameSession);
        }
    }
}