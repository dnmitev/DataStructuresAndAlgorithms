namespace LinkedListDefinition
{
    using System;
    using System.Text;
    
    internal class CustomLinkedList<T> where T : IComparable
    {
        private ListItem<T> firstElement;

        public CustomLinkedList()
        {
            this.firstElement = null;
        }

        public T FirstElement
        {
            get
            {
                return this.firstElement.Value;
            }
        }

        public void AddItem(T element)
        {
            if (this.firstElement == null)
            {
                this.firstElement = new ListItem<T>(element);
            }
            else
            {
                var currentElement = this.firstElement;
                while (currentElement.Next != null)
                {
                    currentElement = currentElement.Next;
                }

                currentElement.Next = new ListItem<T>(element);
            }
        }

        public void RemoveItem(T element)
        {
            if (this.firstElement == null)
            {
                return;
            }

            var currentItem = this.firstElement;

            if (currentItem.Value.CompareTo(element) == 0)
            {
                this.firstElement = currentItem.Next;
                return;
            }

            while (currentItem.Next != null)
            {
                if (currentItem.Next.Value.CompareTo(element) == 0)
                {
                    currentItem.Next = currentItem.Next.Next;
                    return;
                }
                
                currentItem = currentItem.Next;
            }
        }

        public void AddFirst(T element)
        {
            var newItem = new ListItem<T>(element);
            newItem.Next = this.firstElement;
            this.firstElement = newItem;
        }

        public void RemoveFirst()
        {
            this.firstElement = this.firstElement.Next;
        }

        public override string ToString()
        {
            if (this.firstElement == null)
            {
                return string.Format("[ ]");
            }

            StringBuilder sb = new StringBuilder("[ ");

            var currItem = this.firstElement;
            sb.Append(currItem.Value);

            while (currItem.Next != null)
            {
                sb.Append(", ");
                sb.Append(currItem.Next);
                currItem = currItem.Next;
            }

            sb.Append(" ]");

            return sb.ToString();
        }
    }
}