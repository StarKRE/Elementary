using System;
using OregoFramework.Game;

namespace OregoFramework.Domain
{
    /**
     * Managers a game session.
     * Required OregoTimeScaleStack implementation.
     */
    public abstract class OregoGameContextInteractor<T> : OregoInteractor 
        where T : IOregoGameContext
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