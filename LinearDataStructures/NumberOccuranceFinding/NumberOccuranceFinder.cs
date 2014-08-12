// 07. Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.

/* Example: 
 * array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
 * 2 -> 2 times
 * 3 -> 4 times
 * 4 -> 3 times
 */

namespace NumberOccuranceFinding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class NumberOccuranceFinder
    {
        private const int MinRandomValue = 0;
        private const int MaxRandomValue = 1000;

        private const int DefaultIntCount = 10;

        private static void Main()
        {
            var list = GetListWithRandom(20);
            var result = GetNumberOccurances(list);

            Console.WriteLine("List: {0}", string.Join(", ", list));

            foreach (var item in result)
            {
                Console.WriteLine("{0} -> {1} times occured", item.Key, item.Value);
            }
        }

        private static List<int> GetListWithRandom(int count = DefaultIntCount)
        {
            Random randomGenerator = new Random();
            var result = new List<int>();

            for (int i = 0; i < count; i++)
            {
                result.Add(randomGenerator.Next(MinRandomValue, MaxRandomValue + 1));
            }

            return result;
        }

        private static Dictionary<int, int> GetNumberOccurances(List<int> list)
        {
            var numberOccurance = list.GroupBy(x => x).ToDictionary(num => num.Key, num => num.Count());

            return numberOccurance;
        }
    }
}