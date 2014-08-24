namespace LabyrinthPaths
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class EntryPoint
    {
        private const string FreeCell = "0";

        private static void Main()
        {
            string[,] labyrinth = 
            {
                { "0", "0", "0", "X", "0", "X" },
                { "0", "X", "0", "X", "0", "X" },
                { "0", "*", "X", "0", "X", "0" },
                { "0", "X", "0", "0", "0", "0" },
                { "0", "0", "0", "X", "X", "0" },
                { "0", "0", "0", "X", "0", "X" }
            };

            var startCoordinate = new Coordinate(2, 1, 0);
            GetAllPossiblePaths(labyrinth, startCoordinate);
            PrintLabyrinth(labyrinth);
        }

        private static void PrintLabyrinth(string[,] labyrinth)
        {
            int rows = labyrinth.GetLength(0);
            int cols = labyrinth.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write("{0,3}", labyrinth[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void GetAllPossiblePaths(string[,] labyrinth, Coordinate startCoordinate)
        {
            var coordinates = new Queue<Coordinate>();
            coordinates.Enqueue(startCoordinate);
            BFS(coordinates, labyrinth);
        }

        private static void BFS(Queue<Coordinate> coordinates, string[,] labyrinth)
        {
            while (coordinates.Count > 0)
            {
                var currentCoordinate = coordinates.Dequeue();
                var currentX = currentCoordinate.X;
                var currentY = currentCoordinate.Y;
                var currentValue = currentCoordinate.Value + 1;

                if (currentX + 1 < labyrinth.GetLength(0) && labyrinth[currentX + 1, currentY] == FreeCell)
                {
                    labyrinth[currentX + 1, currentY] = currentValue.ToString();
                    coordinates.Enqueue(new Coordinate(currentX + 1, currentY, currentValue));
                }

                if (currentX - 1 >= 0 && labyrinth[currentX - 1, currentY] == FreeCell)
                {
                    labyrinth[currentX - 1, currentY] = currentValue.ToString();
                    coordinates.Enqueue(new Coordinate(currentX - 1, currentY, currentValue));
                }

                if (currentY + 1 < labyrinth.GetLength(1) && labyrinth[currentX, currentY + 1] == FreeCell)
                {
                    labyrinth[currentX, currentY + 1] = currentValue.ToString();
                    coordinates.Enqueue(new Coordinate(currentX, currentY + 1, currentValue));
                }

                if (currentY - 1 >= 0 && labyrinth[currentX, currentY - 1] == FreeCell)
                {
                    labyrinth[currentX, currentY - 1] = currentValue.ToString();
                    coordinates.Enqueue(new Coordinate(currentX, currentY - 1, currentValue));
                }
            }
        }
    }
}