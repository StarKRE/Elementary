namespace ElementaryFramework.Util
{
    public interface ITakeDamageBehaviour : IBehaviour
    {
        AutoEvent<object, ITakeDamageBehaviour, int> OnTakeDamageEvent { get; }

        void OnTakeDamage(object sender, int damage);
    }
}