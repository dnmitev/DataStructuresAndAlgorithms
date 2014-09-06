// 05. Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations Vkn).
// Example: n=3, k=2, set = {hi, a, b} =>(hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)

namespace OrderedSubset
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class OrderedSubsetOfElements
    {
        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());

            string[] set = new string[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter {0} element: ", i + 1);
                set[i] = Console.ReadLine();
            }

            string[] output = new string[k];
            FindCombinations(0, n, set, output);
        }

        private static void FindCombinations(int index, int n, string[] set, string[] output)
        {
            if (index == output.Length)
            {
                Console.WriteLine(string.Join(" ",output));
                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                output[index] = set[i];
                FindCombinations(index + 1, n, set, output);
            }
        }
    }
}
