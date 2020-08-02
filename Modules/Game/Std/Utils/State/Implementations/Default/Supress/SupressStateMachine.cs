using System;
using System.Collections.Generic;

namespace ElementaryFramework.Util
{
    public class SupressStateMachine : StateMachine, ISupressStateController
    {
        protected SupressStateMachine(Type initialStateType, IEnumerable<IState> states)
            : base(initialStateType, states)
        {
        }

        public virtual void SupressState(IState nextState)
        {
            if (!(this.currentState is ISupressState supressState))
            {
                base.SetCurrentState(nextState);
                return;
            }

            nextState = supressState.OnSupress(nextState);
            if (nextState != this.currentState)
            {
                base.SetCurrentState(nextState);
            }
        }
    }
}