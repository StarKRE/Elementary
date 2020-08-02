using UnityEngine;

namespace ElementaryFramework.Util.Gear
{
    public class ChangeVelocityEvent : IEvent
    {
        public float? x { get; set; }

        public float? y { get; set; }

        public float? z { get; set; }

        public ChangeVelocityEvent(float? x, float? y, float? z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public ChangeVelocityEvent(Vector2 vector2)
        {
            this.x = vector2.x;
            this.y = vector2.y;
        }

        public ChangeVelocityEvent(Vector3 vector3)
        {
            this.x = vector3.x;
            this.y = vector3.y;
            this.z = vector3.z;
        }
        
        public Vector2 ToVector2()
        {
            return new Vector2(this.x.Value, this.y.Value);
        }
    }
}