namespace OregoFramework.Util
{
    public interface IAttackBehaviour
    {
        AutoEvent<object, IAttackBehaviour> OnAttackStartedEvent { get; }

        AutoEvent<object, IAttackBehaviour> OnAttackStoppedEvent { get; }

        void OnStartAttack(object sender);

        void OnStopAttack(object sender);
    }
}