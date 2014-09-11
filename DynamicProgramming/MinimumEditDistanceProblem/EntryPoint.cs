namespace MinimumEditDistanceProblem
{
    using System;
    using System.Linq;

    internal class EntryPoint
    {
        private const double DeleteCost = 0.9;
        private const double InsertCost = 0.8;
        private const double ReplaceCost = 1.0;

        private static void Main()
        {
            string word = Console.ReadLine();
            string targetWord = Console.ReadLine();

            var minDistance = GetMinumumEditDistance(word, targetWord);
            Console.WriteLine(minDistance);
        }

        private static double GetMinumumEditDistance(string word, string targetWord)
        {
            int n = word.Length;
            int m = targetWord.Length;

            var costTable = new double[n + 1, m + 1];

            // Fill cost of deletions
            for (int row = 0; row < costTable.GetLength(0); row++)
            {
                costTable[row, 0] = row * DeleteCost;
            }

            // Fill cost of insertions
            for (int col = 0; col < costTable.GetLength(1); col++)
            {
                costTable[0, col] = col * InsertCost;
            }

            // Calculate and choose min cost operations
            for (int i = 1; i < costTable.GetLength(0); i++)
            {
                for (int j = 1; j < costTable.GetLength(1); j++)
                {
                    double cost = targetWord[j - 1] == word[i - 1] ? 0 : ReplaceCost;

                    double delete = costTable[i - 1, j] + DeleteCost;
                    double replace = costTable[i - 1, j - 1] + cost;
                    double insert = costTable[i, j - 1] + InsertCost;

                    costTable[i, j] = Math.Min(Math.Min(delete, insert), replace);
                }
            }

            // uncomment to see the cost table
            //for (int i = 0; i < n+1; i++)
            //{
            //    for (int j = 0; j < m+1; j++)
            //    {
            //        Console.Write("{0,6}",costTable[i,j]);
            //    }

            //    Console.WriteLine();
            //}

            return costTable[n, m];
        }
    }
}