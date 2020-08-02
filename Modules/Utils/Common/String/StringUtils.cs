using System;
using System.Linq;

namespace ElementaryFramework.Util
{
    public static class StringUtils
    {
        #region Const

        private static readonly Random RANDOM = new Random();

        private const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        #endregion

        public static bool IsNotEmpty(this string str)
        {
            return str?.Length > 0;
        }

        public static int ToInt(this string str)
        {
            return int.Parse(str);
        }

        public static string Random(int length)
        {
            return new string(Enumerable
                .Repeat(CHARS, length)
                .Select(s => s[RANDOM.Next(s.Length)])
                .ToArray()
            );
        }
    }
}