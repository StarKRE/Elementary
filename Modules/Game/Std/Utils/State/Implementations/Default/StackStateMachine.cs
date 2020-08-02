using System;
using System.Collections.Generic;

namespace ElementaryFramework.Util
{
    public class StackStateMachine : StateMachine
    {
        private readonly Stack<IState> previousStateStack = new Stack<IState>();

        public StackStateMachine(Type initialStateType, IEnumerable<IState> states) : base(initialStateType, states)
        {
        }

        public void SetPreviousState()
        {
            var previousState = this.previousStateStack.Pop();
            this.SetCurrentState(previousState);
        }

        public override void SetCurrentState(IState nextState)
        {
            this.previousStateStack.Push(this.currentState);
            base.SetCurrentState(nextState);
        }

        public IState GetPreviousState()
        {
            return this.previousStateStack.Peek();
        }

        public bool HasPreviousState()
        {
            return this.previousStateStack.IsNotEmpty();
        }
    }
}