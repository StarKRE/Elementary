namespace OregoFramework.Util
{
    public interface IIncrementHitPointsBehaviour : IBehaviour
    {
        AutoEvent<object, IIncrementHitPointsBehaviour, int> OnHitPointsIncrementedEvent { get; }

        void OnIncrementHitPoints(object sender, int value);
    }
}