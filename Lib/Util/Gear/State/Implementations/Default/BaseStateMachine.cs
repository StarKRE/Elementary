using System;
using System.Collections.Generic;

namespace OregoFramework.Util
{
    public class BaseStateMachine : StateMachine
    {
        private readonly object parent;

        public BaseStateMachine(
            object parent,
            Type initialStateType,
            IEnumerable<BaseState> baseStates
        )
            : base(initialStateType, baseStates)
        {
            this.parent = parent;
        }
        
        protected T GetParent<T>()
        {
            return (T) this.parent;
        }
    }
}