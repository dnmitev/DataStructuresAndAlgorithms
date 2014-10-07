namespace Portals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Portals
    {
        static int[,] maze;
        static int bestSum = int.MinValue;

        static void Main()
        {
            string[] startData = Console.ReadLine().Split(' ');

            int startRow = int.Parse(startData[0]);
            int startCol = int.Parse(startData[1]);

            int[] dimensions = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            maze = new int[dimensions[0], dimensions[1]];

            for (int i = 0; i < dimensions[0]; i++)
            {
                string[] line = Console.ReadLine().Split(' ').ToArray();

                for (int j = 0; j < dimensions[1]; j++)
                {
                    if (line[j] != "#")
                    {
                        maze[i, j] = int.Parse(line[j]);
                    }
                    else
                    {
                        maze[i, j] = -1;
                    }
                }
            }

            //PrintMaze(dimensions);
            BFS(new Position { Row = startRow, Col = startCol, Power = 0, CurrentState = maze });

            Console.WriteLine(bestSum);
        }

        private static void BFS(Position currentPosition)
        {
            if (currentPosition.Power > bestSum)
            {
                bestSum = currentPosition.Power;
            }

            maze = currentPosition.CurrentState;
            var currentPowerLevel = maze[currentPosition.Row, currentPosition.Col];

            if (currentPowerLevel > 0)
            {
                var nextPowerLevel = currentPosition.Power + currentPowerLevel;

                // go up
                var up = currentPosition.Row - currentPowerLevel;
                if (up >= 0 && maze[up, currentPosition.Col] != -1)
                {
                    maze[currentPosition.Row, currentPosition.Col] = 0;
                    BFS(new Position { Row = up, Col = currentPosition.Col, Power = nextPowerLevel, CurrentState = GetState(maze) });
                    maze[currentPosition.Row, currentPosition.Col] = currentPowerLevel;
                }

                // go down
                var down = currentPosition.Row + currentPowerLevel;
                if (down < maze.GetLength(0) && maze[down, currentPosition.Col] != -1)
                {
                    maze[currentPosition.Row, currentPosition.Col] = 0;
                    BFS(new Position { Row = down, Col = currentPosition.Col, Power = nextPowerLevel, CurrentState = GetState(maze) });
                    maze[currentPosition.Row, currentPosition.Col] = currentPowerLevel;
                }

                // go left
                var left = currentPosition.Col - currentPowerLevel;
                if (left >= 0 && maze[currentPosition.Row, left] != -1)
                {
                    maze[currentPosition.Row, currentPosition.Col] = 0;
                    BFS(new Position { Row = currentPosition.Row, Col = left, Power = nextPowerLevel, CurrentState = GetState(maze) });
                    maze[currentPosition.Row, currentPosition.Col] = currentPowerLevel;
                }

                // go right
                var right = currentPosition.Col + currentPowerLevel;
                if (right < maze.GetLength(1) && maze[currentPosition.Row, right] != -1)
                {
                    maze[currentPosition.Row, currentPosition.Col] = 0;
                    BFS(new Position { Row = currentPosition.Row, Col = right, Power = nextPowerLevel, CurrentState = GetState(maze) });
                    maze[currentPosition.Row, currentPosition.Col] = currentPowerLevel;
                }
            }
        }

        private static int[,] GetState(int[,] state)
        {
            var newMaze = new int[state.GetLength(0), state.GetLength(1)];
            for (int i = 0; i < newMaze.GetLength(0); i++)
            {
                for (int j = 0; j < newMaze.GetLength(1); j++)
                {
                    newMaze[i, j] = state[i, j];
                }
            }

            return newMaze;
        }



        private static void PrintMaze(int[] dimensions)
        {
            for (int i = 0; i < dimensions[0]; i++)
            {
                for (int j = 0; j < dimensions[1]; j++)
                {
                    Console.Write("{0,3}", maze[i, j]);
                }

                Console.WriteLine();
            }
        }
    }

    struct Position
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public int Power { get; set; }

        public int[,] CurrentState { get; set; }
    }
}