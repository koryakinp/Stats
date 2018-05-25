using System;
using System.Linq;

namespace Stats
{
    public static class Stats
    {
        public static double Mean(this double[] input)
        {
            if(!input.Any())
            {
                throw new InvalidOperationException(Consts.EMPTY_ARRAY);
            }

            return input.Sum() / input.Count();
        }

        public static double Variance(this double[] input)
        {
            if (!input.Any())
            {
                throw new InvalidOperationException(Consts.EMPTY_ARRAY);
            }

            var mean = input.Mean();

            return input.Sum(q => Math.Pow(q - mean, 2))/input.Count();
        }

        public static double StandardDeviation(this double[] input)
        {
            if (!input.Any())
            {
                throw new InvalidOperationException(Consts.EMPTY_ARRAY);
            }

            return Math.Sqrt(input.Variance());
        }
    }
}
