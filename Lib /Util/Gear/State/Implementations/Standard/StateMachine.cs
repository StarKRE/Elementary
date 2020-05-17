using System;
using System.Collections.Generic;

namespace OregoFramework.Util
{
    public class StateMachine : StateController, IStateMachine
    {
        #region Event

        public AutoEvent<IState> OnEnterEvent { get; }
        
        public AutoEvent<IState> OnUpdateEvent { get; }
        
        public AutoEvent<IState> OnExitEvent { get; }

        #endregion

        protected readonly Dictionary<Type, IState> stateMap;

        public StateMachine(Type initialStateType, IEnumerable<IState> states)
        {
            this.OnEnterEvent = new AutoEvent<IState>();
            this.OnUpdateEvent = new AutoEvent<IState>();
            this.OnExitEvent = new AutoEvent<IState>();
            this.stateMap = new Dictionary<Type, IState>();
            foreach (var state in states)
            {
                this.AddState(state);
            }

            this.currentState = this.stateMap[initialStateType];
        }

        #region Lifecycle

        public virtual void OnEnter()
        {
            this.currentState.OnEnter();
            this.OnEnterEvent?.Invoke(this);
        }

        public virtual void OnUpdate()
        {
            this.currentState.OnUpdate();
            this.OnUpdateEvent?.Invoke(this);
        }

        public virtual void OnExit()
        {
            this.currentState.OnExit();
            this.OnExitEvent?.Invoke(this);
        }

        #endregion

        public void AddState(IState state)
        {
            this.stateMap.AddByType(state);
        }

        public void RemoveState(IState state)
        {
            this.stateMap.RemoveByType(state);
        }

        public T GetState<T>() where T : IState
        {
            return this.stateMap.Find<T, IState>();
        }

        public IEnumerable<T> GetStates<T>() where T : IState
        {
            return this.stateMap.FindAll<T, IState>();
        }

        public override void Dispose()
        {
            base.Dispose();
            this.OnEnterEvent.Dispose();
            this.OnUpdateEvent.Dispose();
            this.OnExitEvent.Dispose();
        }
    }
}