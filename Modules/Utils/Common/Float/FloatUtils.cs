using UnityEngine;

namespace ElementaryFramework.Util
{
    public static class Float
    {
        public const float HUNDREED = 100.0f;

        public const float ZERO = 0.0f;

        public const float ONE = 1.0f;

        public const float HALF = 0.5f;

        public const float HALF_CIRCLE_ANGLE = 180.0f;

        public const float CIRCLE_ANGLE = 360.0f;

        public const float MIN_TOLERANCE = 0.000001f;
    }

    public static class FloatUtils
    {
        public static float Abs(this float value)
        {
            return Mathf.Abs(value);
        }

        public static float Sign(this float value)
        {
            return Mathf.Sign(value);
        }

        public static float ToRadianCos(this float value)
        {
            return Mathf.Cos(value);
        }

        public static float ToRadianSin(this float value)
        {
            return Mathf.Sin(value);
        }

        public static float ToEulerCos(this float eulerAngle)
        {
            return Mathf.Cos(eulerAngle * Mathf.PI / Float.HALF_CIRCLE_ANGLE);
        }

        public static float ToEulerSin(this float eulerAngle)
        {
            return Mathf.Sin(eulerAngle * Mathf.PI / Float.HALF_CIRCLE_ANGLE);
        }

        public static float ToCircleAngle(this float angle)
        {
            var angleSign = angle.Sign();
            var absAngle = angle.Abs();
            while (absAngle >= Float.CIRCLE_ANGLE)
            {
                absAngle -= Float.CIRCLE_ANGLE;
            }

            return absAngle * angleSign;
        }

        public static float ToMinCircleAngle(this float angle)
        {
            angle = angle.ToCircleAngle();
            if (angle >= Float.HALF_CIRCLE_ANGLE)
            {
                angle -= Float.CIRCLE_ANGLE;
            }

            if (angle <= -Float.HALF_CIRCLE_ANGLE)
            {
                angle += Float.CIRCLE_ANGLE;
            }

            return angle;
        }

        public static bool IsPassedZero(float multiplier1, float multiplier2)
        {
            return multiplier1 * multiplier2 <= Float.ZERO;
        }

        public static bool IsPositive(this float value)
        {
            return value > Float.ZERO;
        }

        public static bool IsNegative(this float value)
        {
            return value < Float.ZERO;
        }

        public static bool IsEqual(this float value, float other,
            float tolerance = Float.MIN_TOLERANCE)
        {
            return (value - other).Abs() <= tolerance;
        }

        public static float Normalize(this float value)
        {
            return Mathf.Clamp(value, Float.ZERO, Float.ONE);
        }

        public static float ToPercent(this float value)
        {
            return value.Normalize() * Float.HUNDREED;
        }

        public static bool EqualsSign(this float value, float other)
        {
            return value * other > Float.ZERO;
        }

        public static bool AbsInRange(this float value, float range)
        {
            return value.Abs() <= range;
        }

        public static bool IsNaN(this float value)
        {
            return float.IsNaN(value);
        }
    }
}