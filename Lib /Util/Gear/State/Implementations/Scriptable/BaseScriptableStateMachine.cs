namespace OregoFramework.Util
{
    public abstract class BaseScriptableStateMachine<T> : ScriptableStateMachine,
        IScriptableParentState
    {
        protected T parent { get; private set; }

        public void BindParent(object parent)
        {
            this.parent = (T) parent;
            this.OnBindParent();
        }

        protected virtual void OnBindParent()
        {
            var states = this.GetStates<IScriptableParentState>();
            foreach (var state in states)
            {
                state.BindParent(this.parent);
            }
        }
        
        protected void ChangeState<TState>() where TState : IState
        {
            var nextState = this.GetState<TState>();
            this.SetCurrentState(nextState);
        }
    }
}