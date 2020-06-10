namespace OregoFramework.Util.Gear
{
    public class ChangeRotationEvent : IEvent
    {
        public float? x { get; set; }

        public float? y { get; set; }

        public float? z { get; set; }

        public ChangeRotationEvent(float? x, float? y, float? z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}