// 08. We are given a matrix of passable and non-passable cells. Write a recursive program for finding all paths between two 
// cells in the matrix. Modify the above program to check whether a path exists between two cells without finding all possible paths. Test it over an empty 100 x 100 matrix.

namespace AvailablePathBetweenCells
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class PathChecker
    {
        const string ExitSymbol = "e";
        const string ClearPath = " ";

        static string[,] maze = new string[100, 100];

        static void Main()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    maze[i, j] = ClearPath;
                }
            }

            maze[72, 69] = ExitSymbol;

            Stack<int> stack = new Stack<int>();

            var pathExists = CheckForExistingPath(0, 0, 0, stack);
            Console.WriteLine(pathExists);
        }

        private static bool CheckForExistingPath(int row, int col, int count, Stack<int> stack)
        {
            if (!IsInRange(row, col))
            {
                return false;
            }

            if (maze[row, col] == ExitSymbol)
            {
                return true;
            }

            if (maze[row, col] != ClearPath)
            {
                return false;
            }

            stack.Push(count);
            maze[row, col] = count.ToString();
            count++;

            if (CheckForExistingPath(row, col + 1, count, stack))
            {
                return true;
            }

            if (CheckForExistingPath(row, col - 1, count, stack))
            {
                return true;
            }

            if (CheckForExistingPath(row + 1, col, count, stack))
            {
                return true;
            }

            if (CheckForExistingPath(row - 1, col, count, stack))
            {
                return true;
            }

            maze[row, col] = ClearPath;
            if (stack.Count > 0)
            {
                stack.Pop();
            }

            return false;
        }

        private static bool IsInRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < maze.GetLength(0);
            bool colInRange = col >= 0 && col < maze.GetLength(1);

            return rowInRange && colInRange;
        }
    }
}