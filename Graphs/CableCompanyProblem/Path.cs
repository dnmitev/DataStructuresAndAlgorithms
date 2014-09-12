namespace CableCompanyProblem
{
    using System;

    internal class Path : IComparable<Path>
    {
        public Path(House startHouse, House endHouse, int distance)
        {
            this.StartHouse = startHouse;
            this.EndHouse = endHouse;
            this.Distance = distance;
        }

        public House StartHouse { get; set; }

        public House EndHouse { get; set; }

        public int Distance { get; set; }

        public int CompareTo(Path other)
        {
            return this.Distance.CompareTo(other.Distance);
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}) -> {2}", this.StartHouse, this.EndHouse, this.Distance);
        }
    }
}