namespace ElementaryFramework.Util
{
    //EXPERIMENTAL!
    public delegate void StateTransition<in T1, in T2>(T1 previousState, T2 nextState)
        where T1 : IState
        where T2 : IState;

    public interface IStateTransitionManager
    {
        void AddTransition<T1, T2>(StateTransition<T1, T2> stateTransition)
            where T1 : IState
            where T2 : IState;
        
        void RemoveTransition<T1, T2>()
            where T1 : IState
            where T2 : IState;

        void MakeTransition<T1, T2>()
            where T1 : IState
            where T2 : IState;
    }
}