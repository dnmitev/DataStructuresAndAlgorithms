namespace MaximalPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class MaximumPath
    {
        static long maxSum = 0;
        static HashSet<Node<int>> usedNodes = new HashSet<Node<int>>();

        static void DFS(Node<int> node, long currentSum)
        {
            currentSum += node.Value;
            usedNodes.Add(node);

            for (int i = 0; i < node.Children.Count; i++)
            {
                if (usedNodes.Contains(node.Children[i]))
                {
                    continue;
                }

                DFS(node.Children[i], currentSum);
            }

            if (node.Children.Count == 1&& currentSum > maxSum)
            {
                maxSum = currentSum;
            }
        }

        static void Main()
        {
            Dictionary<int, Node<int>> tree = new Dictionary<int, Node<int>>();
            int numberOfNodes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                var line = Console.ReadLine().Split(new char[] { '<', '-', '(', ')', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var firstNode = int.Parse(line[0]);
                var secondNode = int.Parse(line[1]);

                if (!tree.ContainsKey(firstNode))
                {
                    tree.Add(firstNode, new Node<int>(firstNode));
                }

                if (!tree.ContainsKey(secondNode))
                {
                    tree.Add(secondNode, new Node<int>(secondNode));
                }

                tree[firstNode].Children.Add(tree[secondNode]);
                tree[secondNode].Children.Add(tree[firstNode]);
            }

            foreach (var node in tree)
            {
                if (node.Value.Children.Count == 1)
                {
                    usedNodes.Clear();
                    DFS(node.Value, 0);
                }
            }

            Console.WriteLine(maxSum);
        }
    }

    class Node<T>
    {
        public T Value { get; set; }

        public List<Node<T>> Children { get; set; }

        public bool HasParent { get; set; }

        public bool HasChildren
        {
            get
            {
                return this.Children.Count != 0;
            }
        }

        public Node()
        {
            this.Children = new List<Node<T>>();
        }

        public Node(T value)
            : this()
        {
            this.Value = value;
        }
    }
}