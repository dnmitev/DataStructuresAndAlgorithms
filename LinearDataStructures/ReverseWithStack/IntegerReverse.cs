// 02. Write a program that reads N integers from the console and reverses them using a stack. Use the Stack<int> class.

namespace ReverseWithStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class IntegerReverse
    {
        private static void Main()
        {
            Stack<int> stack = new Stack<int>();

            try
            {
                stack = GetConsoleInput();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            while (stack.Count > 0)
            {
                Console.Write("{0} ", stack.Pop());
            }
        }

        private static Stack<int> GetConsoleInput()
        {
            Console.WriteLine("Please enter numbers:");
            string input = string.Empty;
            Stack<int> result = new Stack<int>();

            while (true)
            {
                input = Console.ReadLine();

                if (input == null || input == string.Empty)
                {
                    break;
                }

                int number = int.Parse(input);

                result.Push(number);
            }

            return result;
        }
    }
}