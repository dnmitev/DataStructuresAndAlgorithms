namespace Task02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    class Program
    {
        static Dictionary<char, int> prices = new Dictionary<char, int>();

        static int n;

        static char[,] m;
        static char[,] b;
        static char[,] d;

        static ICollection<Path> routes = new OrderedBag<Path>();

        static void Main()
        {
            ParseInput();
            InstantiatePrices();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (m[i, j] == '1')
                    {
                        routes.Add(new Path(new City(i), new City(j), Math.Min(prices[b[i, j]],prices[d[i,j]])));
                    }
                }
            }

            ICollection<Path> minSpanningTree = GetMinimumSpanningTree(routes);

            long minCostBuild = 0;
            //Console.WriteLine("All paths that form the minimum spanning tree are:");
            foreach (Path path in minSpanningTree)
            {
                //Console.WriteLine(path);
                minCostBuild += path.Distance;
            }

            Console.WriteLine(minCostBuild);
        }
 
        private static void ParseInput()
        {
            n = int.Parse(Console.ReadLine());

            m = new char[n, n];
            b = new char[n, n];
            d = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    m[i, j] = line[j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    b[i, j] = line[j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    d[i, j] = line[j];
                }
            }
        }
 
        private static void InstantiatePrices()
        {
            for (char i = 'A'; i <= 'Z'; i++)
            {
                prices.Add(i, (int)i - 65);
            }

            for (char i = 'a'; i <= 'z'; i++)
            {
                prices.Add(i, (int)i - 97 + 26);
            }
        }

        private static ICollection<Path> GetMinimumSpanningTree(ICollection<Path> neighborhood)
        {
            OrderedBag<Path> minimumSpanningTree = new OrderedBag<Path>();

            List<HashSet<City>> vertexSets = GetSetWithOneVertex(neighborhood);

            foreach (var path in neighborhood)
            {
                HashSet<City> startCityGropu = GetVertexSet(path.StartCity, vertexSets);
                HashSet<City> endCityGroup = GetVertexSet(path.EndCity, vertexSets);

                if (startCityGropu == null)
                {
                    minimumSpanningTree.Add(path);

                    if (endCityGroup == null)
                    {
                        HashSet<City> newVertexSet = new HashSet<City>();

                        newVertexSet.Add(path.StartCity);
                        newVertexSet.Add(path.EndCity);
                        vertexSets.Add(newVertexSet);
                    }
                    else
                    {
                        endCityGroup.Add(path.StartCity);
                    }
                }
                else
                {
                    if (endCityGroup == null)
                    {
                        startCityGropu.Add(path.EndCity);
                        minimumSpanningTree.Add(path);
                    }
                    else if (startCityGropu != endCityGroup)
                    {
                        startCityGropu.UnionWith(endCityGroup);
                        vertexSets.Remove(endCityGroup);
                        minimumSpanningTree.Add(path);
                    }
                }
            }

            return minimumSpanningTree;
        }

        private static HashSet<City> GetVertexSet(City city, List<HashSet<City>> vertexSets)
        {
            foreach (var vertexSet in vertexSets)
            {
                if (vertexSet.Contains(city))
                {
                    return vertexSet;
                }
            }

            return null;
        }

        private static List<HashSet<City>> GetSetWithOneVertex(ICollection<Path> neighborhood)
        {
            List<HashSet<City>> allSetsWithOneVertex = new List<HashSet<City>>();

            foreach (var path in neighborhood)
            {
                bool startCityAdded = true;
                bool endCityAdded = true;

                foreach (var set in allSetsWithOneVertex)
                {
                    if (startCityAdded && set.Contains(path.StartCity))
                    {
                        startCityAdded = false;
                    }

                    if (endCityAdded && set.Contains(path.EndCity))
                    {
                        endCityAdded = false;
                    }

                    if (!startCityAdded && !endCityAdded)
                    {
                        break;
                    }
                }

                if (startCityAdded)
                {
                    HashSet<City> newSet = new HashSet<City>();
                    newSet.Add(path.StartCity);
                    allSetsWithOneVertex.Add(newSet);
                }
            }

            return allSetsWithOneVertex;
        }
    }

    class City
    {
        public City(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }

        public override string ToString()
        {
            return string.Format("City{0}", this.Id);
        }

        public override bool Equals(object obj)
        {
            var other = obj as City;
            if (other == null)
            {
                throw new ArgumentNullException("City instance .Equals method works with an instance of House");
            }

            return this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }

    class Path : IComparable<Path>
    {
        public Path(City startCity, City endCity, int distance)
        {
            this.StartCity = startCity;
            this.EndCity = endCity;
            this.Distance = distance;
        }

        public City StartCity { get; set; }

        public City EndCity { get; set; }

        public int Distance { get; set; }

        public int CompareTo(Path other)
        {
            return this.Distance.CompareTo(other.Distance);
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}) -> {2}", this.StartCity, this.EndCity, this.Distance);
        }
    }
}