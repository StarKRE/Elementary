namespace OregoFramework.Util.Gear
{
    public class TakeDamageEvent : IEvent
    {
        public int damage { get; set; }

        public TakeDamageEvent(int damage)
        {
            this.damage = damage;
        }
    }
}