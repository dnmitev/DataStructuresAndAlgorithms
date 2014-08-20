// 13. Implement the ADT queue as dynamic linked list. Use generics (LinkedQueue<T>) to allow storing 
// different data types in the queue.

namespace QueueImlementation
{
    using System;
    using System.Linq;

    internal class Demo
    {
        private static void Main()
        {
            var queue = new CustomQueue<int>();

            queue.Enqueue(300);
            queue.Enqueue(200);
            queue.Enqueue(100);

            Console.WriteLine(queue);
            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue);

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue);
        }
    }
}