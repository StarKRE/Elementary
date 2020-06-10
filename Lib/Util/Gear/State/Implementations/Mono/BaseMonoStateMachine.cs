namespace OregoFramework.Util
{
    public abstract class BaseMonoStateMachine : MonoStateMachine,
        IDelegableState
    {
        private object parent;

        public void ProvideParent(object parent)
        {
            this.parent = parent;
            this.OnParentProvided();
        }

        protected virtual void OnParentProvided()
        {
            var states = this.GetStates<IDelegableState>();
            foreach (var state in states)
            {
                state.ProvideParent(this.parent);
            }
        }
        
        protected void ChangeState<TState>() where TState : IState
        {
            var nextState = this.GetState<TState>();
            this.SetCurrentState(nextState);
        }
        
        protected T GetParent<T>()
        {
            return (T) this.parent;
        }
    }
}