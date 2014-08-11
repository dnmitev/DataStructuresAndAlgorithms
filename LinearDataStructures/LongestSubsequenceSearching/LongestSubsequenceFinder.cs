// 04. Write a method that finds the longest subsequence of equal numbers in given List<int> and 
// returns the result as new List<int>. Write a program to test whether the method works correctly.

namespace LongestSubsequenceSearching
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class LongestSubsequenceFinder
    {
        private const int MinRandomValue = 0;
        private const int MaxRandomValue = 3;

        private const int DefaultIntCount = 10;

        static void Main()
        {
            var list = GetListWithRandom(20);
            var result = GetLongestSubsequenceOfEqualElements(list);

            Console.WriteLine("List: {0}", string.Join(", ", list));
            Console.WriteLine("Longest subsequence of equals: {0}", string.Join(", ", result));
        }

        static List<int> GetListWithRandom(int count = DefaultIntCount)
        {
            Random randomGenerator = new Random();
            var result = new List<int>();

            for (int i = 0; i < count; i++)
            {
                result.Add(randomGenerator.Next(MinRandomValue, MaxRandomValue + 1));
            }

            return result;
        }

        static List<int> GetLongestSubsequenceOfEqualElements(List<int> list)
        {
            int currentIntegerStartIndex = 0;

            int bestIntegerStartIndex = 0;
            int bestIntegerCount = 0;

            for (int i = 0; i < list.Count - 1; i++)
            {
                int equalIntegersCount = 1;
                while (i < list.Count - 1 && list[i] == list[i + 1])
                {
                    i++;
                    equalIntegersCount++;
                }

                if (equalIntegersCount > bestIntegerCount)
                {
                    bestIntegerCount = equalIntegersCount;
                    bestIntegerStartIndex = i - equalIntegersCount + 1;
                }
            }

            return list.GetRange(bestIntegerStartIndex, bestIntegerCount);
        }
    }
}