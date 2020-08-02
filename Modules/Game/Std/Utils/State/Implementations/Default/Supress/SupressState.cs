namespace ElementaryFramework.Util
{
    public class SupressState : State, ISupressState
    {
        public virtual IState OnSupress(IState nextState)
        {
            return nextState;
        }
    }
}