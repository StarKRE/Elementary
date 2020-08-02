namespace ElementaryFramework.Util
{
    public interface IDecrementHitPointsBehaviour : IBehaviour
    {
        AutoEvent<object, IDecrementHitPointsBehaviour, int> OnHitPointsDecrementedEvent { get; }

        void OnDecrementHitPoints(object sender, int value);
    }
}