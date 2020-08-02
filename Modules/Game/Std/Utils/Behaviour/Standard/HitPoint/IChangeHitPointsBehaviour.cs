namespace ElementaryFramework.Util
{
    public interface IChangeHitPointsBehaviour : IBehaviour
    {
        AutoEvent<object, IChangeHitPointsBehaviour, int> OnHitPointsChangedEvent { get; }

        void OnChangeHitPoints(object sender, int newHitPoints);
    }
}