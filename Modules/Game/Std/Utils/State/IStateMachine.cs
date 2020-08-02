using System.Collections.Generic;

namespace ElementaryFramework.Util
{
    public interface IStateMachine : IStateController, IState
    {
        T GetState<T>() where T : IState;

        IEnumerable<T> GetStates<T>() where T : IState;
    }
}