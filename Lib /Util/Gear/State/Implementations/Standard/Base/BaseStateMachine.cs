using System;
using System.Collections.Generic;

namespace OregoFramework.Util
{
    public class BaseStateMachine<T> : StateMachine
    {
        protected T parent { get; }

        public BaseStateMachine(T parent, Type initialStateType, IEnumerable<BaseState<T>> baseStates)
            : base(initialStateType, baseStates)
        {
            this.parent = parent;
        }
    }
}