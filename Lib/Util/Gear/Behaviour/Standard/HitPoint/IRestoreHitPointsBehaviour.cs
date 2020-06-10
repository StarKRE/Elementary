namespace OregoFramework.Util
{
    public interface IRestoreHitPointsBehaviour : IBehaviour
    {
        AutoEvent<object, IRestoreHitPointsBehaviour, int> OnHitPointsRestoredEvent { get; }

        void OnRestoreHitPoints(object sender, int value);
    }
}