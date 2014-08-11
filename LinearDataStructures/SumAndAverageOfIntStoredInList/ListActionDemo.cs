// 01. Write a program that reads from the console a sequence of positive integer numbers. The sequence ends when empty line is entered. 
// Calculate and print the sum and average of the elements of the sequence. Keep the sequence in List<int>.

namespace SumAndAverageOfIntStoredInList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class ListActionDemo
    {
        private static void Main()
        {
            List<int> list = new List<int>();

            try
            {
                list = GetConsoleInput();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("List<int>: {0}", string.Join(", ", list));
            Console.WriteLine("Sum: {0}", list.Sum());
            Console.WriteLine("Average: {0}", list.Average());
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

                if (number < 0)
                {
                    throw new ArgumentException("Number should be positive.");
                }
                else
                {
                    result.Add(number);
                }
            }

            return result;
        }
    }
}