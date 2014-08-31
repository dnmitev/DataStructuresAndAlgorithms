// 01. Implement a class PriorityQueue<T> based on the data structure "binary heap".

namespace CustomPriorityQueueImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main()
        {
            var priorityQueue = new PriorityQueue<int, string>();
            var rndGenerator = new Random();

            for (int i = 0; i < 100; i++)
            {
                int number = rndGenerator.Next(0, 100);
                var pair = new KeyValuePair<int, string>(number, string.Format("pesho{0}", number));

                priorityQueue.Add(pair);
            }

            foreach (var item in priorityQueue)
            {
                Console.WriteLine("{0} : {1}", item.Key, item.Value);
            }
        }
    }
}