namespace LabyrinthPaths
{
    internal class Coordinate
    {
        public Coordinate(int x, int y, int value)
        {
            this.X = x;
            this.Y = y;
            this.Value = value;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public int Value { get; private set; }
    }
}