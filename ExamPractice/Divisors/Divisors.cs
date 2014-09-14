// BG CODER: http://bgcoder.com/Contests/Practice/Index/132#2

namespace Divisors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Divisors
    {
        private static readonly HashSet<int> numbers = new HashSet<int>();

        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] digits = new int[n];

            for (int i = 0; i < n; i++)
            {
                digits[i] = int.Parse(Console.ReadLine());
            }

            GeneratePermutations(digits, 0);

            var dict = new SortedDictionary<int, int>();
            foreach (var number in numbers)
            {
                int divisorsCount = 1;

                for (int i = 2; i <= number; i++)
                {
                    if (number % i == 0)
                    {
                        divisorsCount++;
                    }
                }

                dict.Add(number, divisorsCount);
            }

            Console.WriteLine(dict.FirstOrDefault(num => num.Value == dict.Values.Min()).Key);
        }

        private static void GeneratePermutations(int[] arr, int k)
        {
            if (k >= arr.Length)
            {
                GetNumbers(arr);
            }
            else
            {
                GeneratePermutations(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        private static void GetNumbers(int[] arr)
        {
            numbers.Add(int.Parse(string.Join("", arr)));
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}