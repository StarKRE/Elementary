using System;

namespace ElementaryFramework.Util
{
    public class StateController : IStateController, IDisposable
    {
        #region Event

        public AutoEvent<IState> OnStateChangedEvent { get; }

        #endregion

        protected IState currentState { get; set; }

        public StateController()
        {
            this.OnStateChangedEvent = new AutoEvent<IState>();
        }

        public T GetCurrentState<T>() where T : IState
        {
            return (T) this.currentState;
        }

        public virtual void SetCurrentState(IState nextState)
        {
            var previousState = this.currentState;
            previousState.OnExit();
            this.currentState = nextState;
            nextState.OnEnter();
            this.OnStateChangedEvent?.Invoke(this.currentState);
        }

        public virtual void Dispose()
        {
            this.OnStateChangedEvent?.Dispose();
        }
    }
}