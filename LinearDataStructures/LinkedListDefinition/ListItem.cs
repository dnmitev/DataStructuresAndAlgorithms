namespace LinkedListDefinition
{
    using System;

    internal class ListItem<T>
    {
        public ListItem(T value)
        {
            this.Value = value;
            this.Next = null;
        }

        public T Value { get; set; }

        public ListItem<T> Next { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}