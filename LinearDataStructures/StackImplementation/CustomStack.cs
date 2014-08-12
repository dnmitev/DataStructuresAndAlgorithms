namespace StackImplementation
{
    using System;

    internal class CustomStack<T>
    {
        private const int InitialSize = 8;

        private T[] array;

        public CustomStack() : this(InitialSize)
        {
        }

        public CustomStack(int initialSStackSize)
        {
            this.array = new T[initialSStackSize];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count == this.array.Length)
            {
                this.GetArrayLengthDoubled();
            }

            this.array[this.Count] = element;
            this.Count++;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("Stack is empty. You cannot peek.");
            }

            var wantedItem = this.array[this.Count - 1];

            return wantedItem;
        }

        public T Pop()
        {
            this.Count--;
            return this.Peek();
        }

        public override string ToString()
        {
            return string.Join(", ", this.array);
        }

        private void GetArrayLengthDoubled()
        {
            var newArray = new T[this.array.Length * 2];
            Array.Copy(this.array, newArray, this.array.Length);
            this.array = newArray;
        }
    }
}