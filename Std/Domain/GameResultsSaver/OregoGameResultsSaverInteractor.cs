using System;
using System.Collections;
using System.Collections.Generic;
using OregoFramework.Domain;
using OregoFramework.Game;

namespace OregoFramework.Domain
{
    public abstract class OregoGameResultsSaverInteractor : OregoInteractor
    {
        #region Event

        public event Action<object, IOregoGameContext> OnGameResultsSavedEvent;

        #endregion
        
        private IEnumerable<IOregoGameResultsWriterInteractor> gameWriterInteractors;
        
        public override void OnPrepare()
        {
            base.OnPrepare();
            this.gameWriterInteractors = this.GetInteractors<IOregoGameResultsWriterInteractor>();
        }

        public IEnumerator SaveGameResults(object sender, IOregoGameContext gameContext)
        {
            foreach (var gameWriterInteractor in this.gameWriterInteractors)
            {
                yield return gameWriterInteractor.OnWriteGameResults(sender, gameContext);
            }
            
            this.OnGameResultsSavedEvent?.Invoke(sender, gameContext);
        }
    }
}