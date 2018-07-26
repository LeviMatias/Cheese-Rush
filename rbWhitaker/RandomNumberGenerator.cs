using System;
using System.Collections.Generic;
using System.Text;

namespace rbWhitaker
{
    public static class RandomNumberGenerator
    {
        private static readonly Random _generator = new Random();

        public static int NumberBetween(int minimumValue, int maxValue)
        {
            return _generator.Next(minimumValue, maxValue);
        }
    }
}
