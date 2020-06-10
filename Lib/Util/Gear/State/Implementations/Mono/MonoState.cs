namespace OregoFramework.Util
{
    public abstract class MonoState : AutoMonoBehaviour, IState
    {
        #region Event

        public AutoEvent<IState> OnEnterEvent { get; }

        public AutoEvent<IState> OnUpdateEvent { get; }

        public AutoEvent<IState> OnExitEvent { get; }

        #endregion

        protected MonoState()
        {
            this.OnEnterEvent = this.New<AutoEvent<IState>>();
            this.OnUpdateEvent = this.New<AutoEvent<IState>>();
            this.OnExitEvent = this.New<AutoEvent<IState>>();
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
    }
}