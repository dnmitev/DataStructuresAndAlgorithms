// BG CODER: http://bgcoder.com/Contests/Practice/Index/132#3

namespace ColorfullBalls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    internal class Balls
    {
        private static readonly BigInteger[] cache = new BigInteger[30];

        private static void Main()
        {
            string input = Console.ReadLine();
            BigInteger totalPerms = GetFactorial(input.Length);

            Dictionary<char, int> symbolsCount = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!symbolsCount.ContainsKey(input[i]))
                {
                    symbolsCount[input[i]] = 0;
                }

                symbolsCount[input[i]]++;
            }

            foreach (var symbol in symbolsCount)
            {
                totalPerms /= GetFactorial(symbol.Value);
            }

            Console.WriteLine(totalPerms);
        }

        private static BigInteger GetFactorial(int n)
        {
            if (cache[n] == 0)
            {
                if (n == 0)
                {
                    cache[n] = 1;
                }
                else
                {
                    cache[n] = n * GetFactorial(n - 1);
                }
            }

            return cache[n];
        }
    }
}