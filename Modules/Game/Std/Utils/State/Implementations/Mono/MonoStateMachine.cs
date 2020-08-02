using System;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryFramework.Util
{
    public class MonoStateMachine : MonoState, IStateMachine
    {
        #region Event

        public AutoEvent<IState> OnStateChangedEvent { get; }

        #endregion

        protected IState currentState { get; set; }

        protected readonly Dictionary<Type, IState> stateMap;

        [SerializeField]
        private MonoStateMachineParams m_monoStateMachineParams
            = new MonoStateMachineParams();

        public MonoStateMachine()
        {
            this.OnStateChangedEvent = this.New<AutoEvent<IState>>();
            this.stateMap = new Dictionary<Type, IState>();
        }

        protected virtual void Awake()
        {
            var states = this.m_monoStateMachineParams.m_states;
            foreach (var state in states)
            {
                this.stateMap.AddByType(state);
            }

            var initialIndex = this.m_monoStateMachineParams.m_initialIndex;
            var initialState = states[initialIndex];
            var initialStateType = initialState.GetType();
            this.currentState = this.stateMap[initialStateType];
        }

        #region Lifecycle

        public override void OnEnter()
        {
            this.currentState.OnEnter();
            this.OnEnterEvent?.Invoke(this);
        }

        public override void OnUpdate()
        {
            this.currentState.OnUpdate();
            this.OnUpdateEvent?.Invoke(this);
        }

        public override void OnExit()
        {
            this.currentState.OnExit();
            this.OnExitEvent?.Invoke(this);
        }

        #endregion

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

        public T GetState<T>() where T : IState
        {
            return this.stateMap.Find<T, IState>();
        }

        public IEnumerable<T> GetStates<T>() where T : IState
        {
            return this.stateMap.FindAll<T, IState>();
        }
        
        [Serializable]
        public sealed class MonoStateMachineParams
        {
            [SerializeField]
            public MonoState[] m_states;

            [SerializeField]
            public int m_initialIndex;
        }
    }
}