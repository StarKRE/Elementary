namespace OregoFramework.Util
{
    public class SupressStateController : StateController, ISupressStateController
    {
        public void SupressState(IState nextState)
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