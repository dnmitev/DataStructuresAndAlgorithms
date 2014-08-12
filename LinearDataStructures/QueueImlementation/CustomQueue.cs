namespace QueueImlementation
{
    using System.Collections.Generic;

    internal class CustomQueue<T>
    {
        private readonly LinkedList<T> list;

        public CustomQueue()
        {
            this.list = new LinkedList<T>();
        }

        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }

        public void Enqueue(T element)
        {
            this.list.AddFirst(element);
        }

        public T Peek()
        {
            return this.list.First.Value;
        }

        public T Dequeue()
        {
            var wantedItem = this.Peek();
            this.list.RemoveFirst();
            return wantedItem;
        }

        public override string ToString()
        {
            return string.Join(", ", this.list);
        }
    }
}