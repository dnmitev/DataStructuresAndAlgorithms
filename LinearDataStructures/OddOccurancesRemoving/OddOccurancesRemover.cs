// 06. Write a program that removes from given sequence all numbers that occur odd number of times. Example:

namespace OddOccurancesRemoving
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class OddOccurancesRemover
    {
        private const int MinRandomValue = 0;
        private const int MaxRandomValue = 10;

        private const int DefaultIntCount = 10;

        private static void Main()
        {
            var list = GetListWithRandom(20);
            var result = RemoveElementsOccuringOddTimes(list);

            Console.WriteLine("List: {0}", string.Join(", ", list));
            Console.WriteLine("New list {0}", string.Join(", ", result));
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

        private static List<int> RemoveElementsOccuringOddTimes(List<int> list)
        {
            var numberOccurance = list.GroupBy(x => x).ToDictionary(num => num.Key, num => num.Count());
            var result = list.Where(num => numberOccurance[num] % 2 == 0);

            return result.ToList();
        }
    }
}