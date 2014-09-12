// You are given a cable TV company. The company needs to lay cable to a new neighborhood (for every house). If it is constrained 
// to bury the cable only along certain paths, then there would be a graph representing which points are connected by those paths.
// But the cost of some of the paths is more expensive because they are longer. If every house is a node and every path from house
// to house is an edge, find a way to minimize the cost for cables.
namespace CableCompanyProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    internal class EntryPoint
    {
        private static void Main()
        {
            ICollection<Path> neighborhood = GetNeighborhood();
            ICollection<Path> minSpanningTree = GetMinimumSpanningTree(neighborhood);

            long minCost = 0;
            Console.WriteLine("All paths that form the minimum spanning tree are:");
            foreach (Path path in minSpanningTree)
            {
                Console.WriteLine(path);
                minCost += path.Distance;
            }

            Console.WriteLine("The minimal cost is: {0}", minCost);
        }

        private static ICollection<Path> GetMinimumSpanningTree(ICollection<Path> neighborhood)
        {
            OrderedBag<Path> minimumSpanningTree = new OrderedBag<Path>();

            List<HashSet<House>> vertexSets = GetSetWithOneVertex(neighborhood);

            foreach (var path in neighborhood)
            {
                HashSet<House> startHouseGropu = GetVertexSet(path.StartHouse, vertexSets);
                HashSet<House> endHouseGroup = GetVertexSet(path.EndHouse, vertexSets);

                if (startHouseGropu == null)
                {
                    minimumSpanningTree.Add(path);

                    if (endHouseGroup == null)
                    {
                        HashSet<House> newVertexSet = new HashSet<House>();

                        newVertexSet.Add(path.StartHouse);
                        newVertexSet.Add(path.EndHouse);
                        vertexSets.Add(newVertexSet);
                    }
                    else
                    {
                        endHouseGroup.Add(path.StartHouse);
                    }
                }
                else
                {
                    if (endHouseGroup == null)
                    {
                        startHouseGropu.Add(path.EndHouse);
                        minimumSpanningTree.Add(path);
                    }
                    else if (startHouseGropu != endHouseGroup)
                    {
                        startHouseGropu.UnionWith(endHouseGroup);
                        vertexSets.Remove(endHouseGroup);
                        minimumSpanningTree.Add(path);
                    }
                }
            }

            return minimumSpanningTree;
        }

        private static HashSet<House> GetVertexSet(House house, List<HashSet<House>> vertexSets)
        {
            foreach (var vertexSet in vertexSets)
            {
                if (vertexSet.Contains(house))
                {
                    return vertexSet;
                }
            }

            return null;
        }

        private static List<HashSet<House>> GetSetWithOneVertex(ICollection<Path> neighborhood)
        {
            List<HashSet<House>> allSetsWithOneVertex = new List<HashSet<House>>();

            foreach (var path in neighborhood)
            {
                bool startHouseAdded = true;
                bool endHouseAdded = true;

                foreach (var set in allSetsWithOneVertex)
                {
                    if (startHouseAdded && set.Contains(path.StartHouse))
                    {
                        startHouseAdded = false;
                    }

                    if (endHouseAdded && set.Contains(path.EndHouse))
                    {
                        endHouseAdded = false;
                    }

                    if (!startHouseAdded && !endHouseAdded)
                    {
                        break;
                    }
                }

                if (startHouseAdded)
                {
                    HashSet<House> newSet = new HashSet<House>();
                    newSet.Add(path.StartHouse);
                    allSetsWithOneVertex.Add(newSet);
                }
            }

            return allSetsWithOneVertex;
        }

        private static ICollection<Path> GetNeighborhood()
        {
            OrderedBag<Path> neighborhood = new OrderedBag<Path>();

            // check the picture
            neighborhood.Add(new Path(new House("1"), new House("2"), 10));
            neighborhood.Add(new Path(new House("1"), new House("3"), 2));
            neighborhood.Add(new Path(new House("2"), new House("4"), 5));
            neighborhood.Add(new Path(new House("2"), new House("6"), 19));
            neighborhood.Add(new Path(new House("3"), new House("4"), 3));
            neighborhood.Add(new Path(new House("3"), new House("5"), 2));
            neighborhood.Add(new Path(new House("4"), new House("5"), 11));
            neighborhood.Add(new Path(new House("4"), new House("6"), 9));
            neighborhood.Add(new Path(new House("6"), new House("7"), 1));

            return neighborhood;
        }
    }
}