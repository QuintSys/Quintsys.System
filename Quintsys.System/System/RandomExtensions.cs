using System;

namespace Quintsys.System
{
    public static class RandomExtensions    
    {
        public static decimal RandomDecimal(this Random random, decimal min, decimal max)
        {
            return (decimal)(random.NextDouble() * (double)(max - min)) + min;
        }
    }
}
