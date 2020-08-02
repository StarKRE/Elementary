using System;

namespace ElementaryFramework.Util
{
    public class State : IState, IDisposable
    {
        #region Event

        public AutoEvent<IState> OnEnterEvent { get; }
        
        public AutoEvent<IState> OnUpdateEvent { get; }
        
        public AutoEvent<IState> OnExitEvent { get; }

        #endregion

        public State()
        {
            this.OnEnterEvent = new AutoEvent<IState>();
            this.OnUpdateEvent = new AutoEvent<IState>();
            this.OnExitEvent = new AutoEvent<IState>();
        }

        #region Lifecycle

        public virtual void OnEnter()
        {
            this.OnEnterEvent?.Invoke(this);
        }

        public virtual void OnUpdate()
        {
            this.OnUpdateEvent?.Invoke(this);
        }

        public virtual void OnExit()
        {
            this.OnExitEvent?.Invoke(this);
        }

        #endregion

        public void Dispose()
        {
            this.OnEnterEvent?.Dispose();
            this.OnUpdateEvent?.Dispose();
            this.OnExitEvent?.Dispose();
        }
    }
}