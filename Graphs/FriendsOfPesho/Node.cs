namespace FriendsOfPesho
{
    using System;

    public class Node : IComparable
    {
        public Node(int id)
        {
            this.Id = id;
            this.IsHospital = false;
        }

        public int Id { get; set; }

        public long DijkstraDistance { get; set; }

        public bool IsHospital { get; set; }

        public int CompareTo(object obj)
        {
            var other = obj as Node;

            if (other == null)
            {
                throw new InvalidOperationException("You can compare Nodes only by their Dijkstra distance.");
            }

            return this.DijkstraDistance.CompareTo(other.DijkstraDistance);
        }
    }
}