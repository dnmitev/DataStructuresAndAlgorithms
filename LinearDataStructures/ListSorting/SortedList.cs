// 03. Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order.

namespace ListSorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class SortedList
    {
        private static void Main()
        {
            List<int> list = new List<int>();

            try
            {
                list = GetConsoleInput();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("List<int>: {0}", string.Join(", ", list));
            list.Sort();
            Console.WriteLine("Sorted List<int>: {0}", string.Join(", ", list));
        }

        private static List<int> GetConsoleInput()
        {
            Console.WriteLine("Please enter numbers:");
            string input = string.Empty;
            List<int> result = new List<int>();

            while (true)
            {
                input = Console.ReadLine();

                if (input == null || input == string.Empty)
                {
                    break;
                }

                int number = int.Parse(input);

                result.Add(number);
            }

            return result;
        }
    }
}