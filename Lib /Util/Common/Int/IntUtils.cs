using System;

namespace OregoFramework.Util
{
    public static class Int
    {
        public const int ZERO = 0;

        public const int ONE = 1;

        public const int TWO = 2;
    }

    public static class IntUtils
    {
        public static bool IsPositive(this int value)
        {
            return value > Int.ZERO;
        }

        public static bool IsNegative(this int value)
        {
            return value < Int.ZERO;
        }

        public static int Abs(this int value)
        {
            return Math.Abs(value);
        }

        public static void Times(this int count, Action action)
        {
            for (var i = Int.ZERO; i < count; i++)
            {
                action.Invoke();
            }
        }

        public static int Random(int min, int max)
        {
            return new Random().Next(min, max);
        }

        public static int RandomSign()
        {
            var random = new Random();
            var value = random.Next(Int.ZERO, Int.TWO);
            if (value == Int.ONE)
            {
                return Int.ONE;
            }

            return -Int.ONE;
        }

        public static bool ToBool(this int value)
        {
            return value > 0;
        }
    }
}