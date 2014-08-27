// 01. Write a program that counts in a given array of double values the number of occurrences of each value. Use Dictionary<TKey,TValue>.

namespace CountDoubles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class DoublesCounter
    {
        private static void Main()
        {
            double[] input = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            Dictionary<double, int> doublesCount = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!doublesCount.ContainsKey(input[i]))
                {
                    doublesCount[input[i]] = 0;
                }

                doublesCount[input[i]]++;
            }

            foreach (var d in doublesCount)
            {
                Console.WriteLine("{0} -> count: {1}", d.Key, d.Value); 
            }        }
    }
}