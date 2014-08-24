namespace ActionsOnTrees
{
    using System.Collections.Generic;

    internal class Node<T>
    {
        public T Value { get; set; }

        public List<Node<T>> Children { get; set; }

        public bool HasParent { get; set; }

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