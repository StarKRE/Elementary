using System;
using OregoFramework.Game;

namespace OregoFramework.Domain
{
    /**
     * Managers a game session.
     * Required TimeScaleStack implementation.
     */
    public abstract class GameContextInteractor<T> : Interactor 
        where T : IGameContext
    {
        #region Event

        public abstract event Action<object, T> OnGameCreatedEvent;

        public abstract event Action<object, T> OnGameDestroyedEvent;

        #endregion

        public T gameContext { get; protected set; }

        public abstract void CreateGame(object sender);
        
        public abstract void DestroyGame(object sender);
    }
}