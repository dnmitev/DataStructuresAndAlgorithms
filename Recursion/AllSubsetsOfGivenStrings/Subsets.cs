// 06. Write a program for generating and printing all subsets of k strings from given set of strings.
// Example: s = {test, rock, fun}, k=2 -> (test rock),  (test fun),  (rock fun)

namespace AllSubsetsOfGivenStrings
{
    using System;
    using System.Linq;

    internal class Subsets
    {
        private static void Main()
        {
            int n = 3;
            int k = 2;

            string[] set = new string[3] { "beer", "whiskey", "rum" };
            string[] output = new string[k];

            FindCombinations(0, n, 0, set, output);
        }

        private static void FindCombinations(int index, int n, int start, string[] set, string[] output)
        {
            if (index == output.Length)
            {
                Console.WriteLine(string.Join(" ", output));
            }
            else
            {
                for (int i = start; i < set.Length; i++)
                {
                    output[index] = set[i];
                    FindCombinations(index + 1, n, i + 1, set, output);
                }
            }
        }
    }
}