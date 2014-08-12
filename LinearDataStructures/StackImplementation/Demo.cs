// 12. Implement the ADT stack as auto-resizable array. Resize the capacity on demand (when no space is 
// available to add / insert a new element).

namespace StackImplementation
{
    using System;
    using System.Linq;

    internal class Demo
    {
        private static void Main()
        {
            var stack = new CustomStack<int>();

            for (int i = 0; i < 8; i++)
            {
                stack.Push(i);
            }

            Console.WriteLine(stack);
            Console.WriteLine("Count: {0}", stack.Count);

            stack.Push(100);
            Console.WriteLine(stack);
            Console.WriteLine("Count: {0}", stack.Count);

            Console.WriteLine(stack.Peek());

            stack.Pop();
            Console.WriteLine(stack);
            Console.WriteLine("Count: {0}", stack.Count);
        }
    }
}