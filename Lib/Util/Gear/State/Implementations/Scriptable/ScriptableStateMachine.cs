using System;
using System.Collections.Generic;
using UnityEngine;

namespace OregoFramework.Util
{
    [CreateAssetMenu(
        fileName = "ScriptableStateMachine",
        menuName = "Orego/Util/ScriptableStateMachine/New"
    )]
    public class ScriptableStateMachine : ScriptableState, IStateMachine
    {
        #region Event

        public AutoEvent<IState> OnStateChangedEvent { get; }

        #endregion

        protected IState currentState { get; set; }

        protected readonly Dictionary<Type, IState> stateMap;

        [SerializeField]
        private ScriptableStateMachineParams m_scriptableStateMachineParams
            = new ScriptableStateMachineParams();

        public ScriptableStateMachine()
        {
            this.OnStateChangedEvent = this.New<AutoEvent<IState>>();
            this.stateMap = new Dictionary<Type, IState>();
        }

        public override void OnCreate()
        {
            base.OnCreate();
            var assets = this.m_scriptableStateMachineParams.m_scriptableStateAssets;
            foreach (var asset in assets)
            {
                var state = this.New(asset);
                this.stateMap.AddByType(state);
            }

            var initialIndex = this.m_scriptableStateMachineParams.m_initialIndex;
            var initialState = assets[initialIndex];
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
        public sealed class ScriptableStateMachineParams
        {
            [SerializeField]
            public ScriptableState[] m_scriptableStateAssets;

            [SerializeField]
            public int m_initialIndex;
        }
    }
}