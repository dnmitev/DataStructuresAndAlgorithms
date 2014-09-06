// 07. We are given a matrix of passable and non-passable cells. Write a recursive program for finding all paths 
// between two cells in the matrix.

namespace AllPathsInLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class PathInLabyrinth
    {
        const char ExitChar = 'e';
        const char ClearPath = ' ';
        const char VisitedCell = 'v';

        const char Up = 'U';
        const char Down = 'D';
        const char Left = 'L';
        const char Right = 'R';

        static char[,] maze = 
        {
            { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
            { '*', '*', ' ', '*', ' ', '*', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', '*', '*', '*', '*', '*', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', 'e' },
        };

        static Stack<char> path = new Stack<char>();

        static void Main()
        {
            FindPathToExit(0, 0, 'S');
        }

        private static void FindPathToExit(int row, int col, char direction)
        {
            if (!IsInRange(row, col))
            {
                return;
            }

            path.Push(direction);

            if (maze[row, col] == ExitChar)
            {
                Console.WriteLine(string.Join(" -> ",path));
            }

            if (maze[row,col] == ClearPath)
            {
                // temporarily mark current cell as visited
                maze[row, col] = VisitedCell;

                FindPathToExit(row + 1, col, Down);
                FindPathToExit(row - 1, col, Up);
                FindPathToExit(row, col + 1, Right);
                FindPathToExit(row, col-1, Left);

                maze[row, col] = ClearPath;
            }

            path.Pop();
        }

        private static bool IsInRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < maze.GetLength(0);
            bool colInRange = col >= 0 && col < maze.GetLength(1);

            return rowInRange && colInRange;
        }
    }
}