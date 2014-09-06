// 04. Write a recursive program for generating and printing all permutations of the numbers 1, 2, ..., n for given integer number n.
// Example:	n=3 -> {1, 2, 3}, {1, 3, 2}, {2, 1, 3},{2, 3, 1}, {3, 1, 2},{3, 2, 1}

namespace Permutations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Permutations
    {
        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            int[] vector = new int[n];
            bool[] isUsed = new bool[n]; // contains info if the value is already used or not

            FindPermutations(vector, isUsed, 0);
        }

        private static void FindPermutations(int[] vector, bool[] isUsed, int index)
        {
            if (index == vector.Length)
            {
                Print(vector);
                return;
            }

            for (int i = 0; i < vector.Length; i++)
            {
                if (!isUsed[i])
                {
                    isUsed[i] = true;
                    vector[index] = i + 1;

                    FindPermutations(vector, isUsed, index + 1);

                    isUsed[i] = false;
                }
            }
        }

        private static void Print(int[] vector)
        {
            Console.WriteLine(string.Join(" ", vector));
        }
    }
}