// 01. You are given a tree of N nodes represented as a set of N-1 pairs of nodes (parent node, child node), each in the range (0..N-1).
// Write a program to read the tree and find:
// a)   the root node
// b)   all leaf nodes
// c)   all middle nodes
// d)   the longest path in the tree
// e)   * all paths in the tree with given sum S of their nodes
// f)   * all subtrees with given sum S of their nodes

namespace ActionsOnTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class TreeDemo
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var nodes = new Node<int>[n];

            for (int i = 0; i < n; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 1; i <= n - 1; i++)
            {
                var userLine = Console.ReadLine();
                var edges = userLine.Split(' ');

                int parentValue = int.Parse(edges[0]);
                int childValue = int.Parse(edges[1]);

                nodes[parentValue].Children.Add(nodes[childValue]);
                nodes[childValue].HasParent = true;
            }

            // a) find the tree root
            var root = GetRoot(nodes);
            Console.WriteLine("The tree root is: {0}", root.Value);

            // b) all leaf nodes
            var leafs = GetAllLeafs(nodes);
            Console.Write("Leafs: ");
            foreach (var leaf in leafs)
            {
                Console.Write("{0}, ", leaf.Value);
            }

            Console.WriteLine();

            // c)   all middle nodes
            var middleNodes = GetMiddleNodes(nodes);
            Console.Write("Middle nodes: ");
            foreach (var middleNode in middleNodes)
            {
                Console.Write("{0}, ", middleNode.Value);
            }

            Console.WriteLine();

            // d)   the longest path in the tree
            var longestPath = GetLongestPath(nodes);
            Console.WriteLine("The longest path is: {0}", longestPath);

            //// e)   * all paths in the tree with given sum S of their nodes
            //Console.Write("Find all paths with sum: ");
            //int givenSum = int.Parse(Console.ReadLine());

            //GetAllPathsWithGivenSum(root, givenSum);
            ////foreach (var path in paths)
            ////{
            ////    Console.WriteLine(string.Join(" -> ",path));
            ////}
        }

        private static void GetAllPathsWithGivenSum(Node<int> root, int givenSum)
        {

            if (root == null)
            {
                return;
            }

            int sum = 0;
            Node<int> child = null;
            var list = new List<int>();
            for (int i = 0; i < root.Children.Count; i++)
            {
                child = root.Children[i];

                if (child.Value == givenSum)
                {
                    Console.WriteLine(child.Value);
                }

                sum += child.Value;
                list.Add(child.Value);

                if (sum == child.Value)
                {
                    Console.WriteLine(string.Join(" -> ", list));
                }
                GetAllPathsWithGivenSum(child, givenSum);
            }
        }

        private static int GetLongestPath(Node<int>[] nodes)
        {
            var paths = new List<int>();
            var root = GetRoot(nodes);
            foreach (var child in root.Children)
            {
                paths.Add(GetTreeHeight(child));
            }

            paths = paths.OrderByDescending(x => x).ToList();
            int maxPath = paths[0] + paths[1] + 1;

            return maxPath;
        }

        private static int GetTreeHeight(Node<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 1;
            }

            int height = 0;
            foreach (var node in root.Children)
            {
                height = Math.Max(height, GetTreeHeight(node));
            }

            return height + 1;
        }

        private static List<Node<int>> GetMiddleNodes(Node<int>[] nodes)
        {
            var middleNodes = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.Children.Count != 0 && node.HasParent)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        private static List<Node<int>> GetAllLeafs(Node<int>[] nodes)
        {
            var leafs = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.Children.Count == 0)
                {
                    leafs.Add(node);
                }
            }

            return leafs;
        }

        private static Node<int> GetRoot(Node<int>[] nodes)
        {
            foreach (var node in nodes)
            {
                if (node.HasParent == false)
                {
                    return node;
                }
            }

            throw new ArgumentException("The tree has no root.");
        }
    }
}