// 05. Write a program that removes from given sequence all negative numbers.

namespace RemovingNegative
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class NegativeRemover
    {
        private const int MinRandomValue = -10;
        private const int MaxRandomValue = 10;

        private const int DefaultIntCount = 10;

        static void Main()
        {
            var list = GetListWithRandom(25);
            Console.WriteLine("List: {0}", string.Join(", ", list));

            list.RemoveAll(x => x < 0);
            Console.WriteLine("List without negative members: {0}", string.Join(", ", list));
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
    }
}
