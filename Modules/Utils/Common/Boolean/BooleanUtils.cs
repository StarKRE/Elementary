using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementaryFramework.Util
{
    public static class BooleanUtils
    {
        private static readonly Random RANDOM = new Random();
        
        public static bool RandomBoolean()
        {
            var value = RANDOM.Next(Int.TWO);
            return value == Int.ONE;
        }
        
        public static int ToInt(this bool boolean)
        {
            return boolean ? Int.ONE : Int.ZERO;
        }
    }
}