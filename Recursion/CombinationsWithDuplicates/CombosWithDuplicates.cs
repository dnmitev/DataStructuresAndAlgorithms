// 02. Write a recursive program for generating and printing all the combinations with duplicates of k elements from n-element set. 
// Example:	n=3, k=2 -> (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)

namespace CombinationsWithDuplicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class CombosWithDuplicates // Find All Variations Problems
    {
        private static int n;
        private static int k;
        private static int[] variation;

        static void Main()
        {
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());

            Console.Write("k = ");
            k = int.Parse(Console.ReadLine());

            variation = new int[k];

            FindtVariation(0);
        }

        private static void FindtVariation(int currentNumber)
        {
            if (currentNumber == k)
            {
                Print();
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                variation[currentNumber] = i;
                FindtVariation(currentNumber + 1);
            }
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(" ", variation));
        }
    }
}