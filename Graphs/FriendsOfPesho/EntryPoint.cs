namespace FriendsOfPesho
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class EntryPoint
    {
        public static void DijkstraAlgorithm(Dictionary<Node, List<Connection>> graph, Node source)
        {
            PriorityQueue<Node> queue = new PriorityQueue<Node>();

            foreach (var item in graph)
            {
                item.Key.DijkstraDistance = long.MaxValue;
            }

            queue.Enqueue(source);
            source.DijkstraDistance = 0;

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                foreach (var connection in graph[currentNode])
                {
                    var dist = connection.Distance + currentNode.DijkstraDistance;

                    if (dist < connection.ToNode.DijkstraDistance)
                    {
                        connection.ToNode.DijkstraDistance = dist;
                        queue.Enqueue(connection.ToNode);
                    }
                }
            }
        }

        private static void Main()
        {
            string[] data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int streetsCount = int.Parse(data[1]);

            string[] hospitals = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Storage of the unique nodes
            Dictionary<int, Node> uniqueNodes = new Dictionary<int, Node>();

            // Storaga of the Node-Connection pair
            Dictionary<Node, List<Connection>> graph = new Dictionary<Node, List<Connection>>();

            for (int i = 0; i < streetsCount; i++)
            {
                string[] connection = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int firstNode = int.Parse(connection[0]);
                int secondNode = int.Parse(connection[1]);
                int distance = int.Parse(connection[2]);

                if (!uniqueNodes.ContainsKey(firstNode))
                {
                    Node firstUniqueNode = new Node(firstNode);
                    uniqueNodes.Add(firstNode, firstUniqueNode);
                }

                if (!uniqueNodes.ContainsKey(secondNode))
                {
                    Node secondUniqueNode = new Node(secondNode);
                    uniqueNodes.Add(secondNode, secondUniqueNode);
                }

                if (!graph.ContainsKey(uniqueNodes[firstNode]))
                {
                    graph.Add(uniqueNodes[firstNode], new List<Connection>());
                }

                if (!graph.ContainsKey(uniqueNodes[secondNode]))
                {
                    graph.Add(uniqueNodes[secondNode], new List<Connection>());
                }

                graph[uniqueNodes[firstNode]].Add(new Connection(uniqueNodes[secondNode], distance));
                graph[uniqueNodes[secondNode]].Add(new Connection(uniqueNodes[firstNode], distance));
            }

            List<int> allHospitals = new List<int>();

            for (int i = 0; i < hospitals.Length; i++)
            {
                int currentHospital = int.Parse(hospitals[i]);
                allHospitals.Add(currentHospital);
                uniqueNodes[currentHospital].IsHospital = true;
            }

            long minDijkstraDistance = long.MaxValue;

            for (int i = 0; i < allHospitals.Count; i++)
            {
                DijkstraAlgorithm(graph, uniqueNodes[allHospitals[i]]);

                long sum = 0;

                foreach (var item in uniqueNodes)
                {
                    if (!item.Value.IsHospital)
                    {
                        sum += item.Value.DijkstraDistance;
                    }
                }

                if (sum < minDijkstraDistance)
                {
                    minDijkstraDistance = sum;
                }
            }

            Console.WriteLine(minDijkstraDistance);
        }
    }
}