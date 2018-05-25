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

        public static double Variance(this double[] input, VarianceType type)
        {
            if (!input.Any())
            {
                throw new InvalidOperationException(Consts.EMPTY_ARRAY);
            }
            else if(input.Count() == 1 && type == VarianceType.Sample)
            {
                throw new InvalidOperationException(Consts.INVALID_SAMPLE_FOR_VARIANCE);
            }

            var mean = input.Mean();
            int divisor = type == VarianceType.Population ? input.Count() : input.Count() - 1;
            return input.Sum(q => Math.Pow(q - mean, 2))/divisor;
        }

        public static double StandardDeviation(this double[] input, VarianceType type)
        {
            if (!input.Any())
            {
                throw new InvalidOperationException(Consts.EMPTY_ARRAY);
            }

            return Math.Sqrt(input.Variance(type));
        }
    }
}
