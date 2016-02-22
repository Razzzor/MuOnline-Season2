using System;


namespace Common.Utility
{
    public static class Randomizer
    {
        private static readonly Random random = new Random((int)DateTime.Now.Ticks);

        public static Random Random()
        {
            return random;
        }

        public static double GetDouble()
        {
            return random.NextDouble();
        }
        public static double GetInt()
        {
            return random.Next();
        }
	}
}