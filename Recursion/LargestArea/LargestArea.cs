// 09. Write a recursive program to find the largest connected area of adjacent empty cells in a matrix.

namespace LargestArea
{
    using System;
    using System.Linq;

    internal class LargestArea
    {
        private static readonly string[,] matrix =
        {
            { "*", " ", "*", "*", " ", " ", " " },
            { " ", " ", " ", "*", " ", "*", " " },
            { " ", " ", " ", "*", " ", "*", " " },
            { "*", " ", "*", "*", "*", "*", "*" },
            { " ", " ", " ", "*", " ", " ", " " },
        };

        private static int maxSum = 0;
        private static int count = 0;

        private static void Main()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == " ")
                    {
                        DFS(i, j);

                        if (count > maxSum)
                        {
                            maxSum = count;
                        }
                        count = 0;
                    }
                }
            }

            Console.WriteLine(maxSum);
        }

        private static void DFS(int row, int col)
        {
            if (!IsInRange(row, col) || matrix[row, col] != " ")
            {
                return;
            }

            matrix[row, col] = count.ToString();
            
            count++;

            DFS(row, col + 1);
            DFS(row + 1, col);
            DFS(row, col - 1);
            DFS(row - 1, col);
        }

        private static bool IsInRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < matrix.GetLength(0);
            bool colInRange = col >= 0 && col < matrix.GetLength(1);

            return rowInRange && colInRange;
        }
    }
}