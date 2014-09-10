namespace SetOfBalls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class VariationsCounter
    {
        public BigInteger GetVariations(string pattern)
        {
            int n = (pattern.Trim()).Length;

            BigInteger result = this.GetFactorial(n);
            var differentBalls = this.GetDifferentBallsCount(pattern);

            foreach (var ball in differentBalls)
            {
                int count = ball.Value;
                BigInteger currentVariations = this.GetFactorial(count);

                result /= currentVariations;
            }

            return result;
        }

        private BigInteger GetFactorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return (BigInteger)n * this.GetFactorial(n - 1);
            }
        }

        private IDictionary<char, int> GetDifferentBallsCount(string pattern)
        {
            var result = new Dictionary<char, int>();

            for (int i = 0; i < pattern.Length; i++)
            {
                if (!result.ContainsKey(pattern[i]))
                {
                    result[pattern[i]] = 0;
                }

                result[pattern[i]]++;
            }

            return result;
        }
    }
}