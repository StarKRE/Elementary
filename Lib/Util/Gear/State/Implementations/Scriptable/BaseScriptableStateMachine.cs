namespace OregoFramework.Util
{
    public abstract class BaseScriptableStateMachine : ScriptableStateMachine,
        IDelegableState
    {
        private object parent;

        public void ProvideParent(object parent)
        {
            this.parent = parent;
            this.OnBindParent();
        }

        protected virtual void OnBindParent()
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