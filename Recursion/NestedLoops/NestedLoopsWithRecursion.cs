// 01. Write a recursive program that simulates the execution of n nested loops from 1 to n.

namespace NestedLoops
{
    using System;
    using System.Linq;

    internal class NestedLoopsWithRecursion
    {
        private static void Main()
        {
            Console.Write("n = ");
            int number = int.Parse(Console.ReadLine());

            int[] vector = new int[number];
            ExcuteNestedLoops(number - 1, vector);
        }

        private static void ExcuteNestedLoops(int index, int[] vector)
        {
            if (index == -1)
            {
                // bottom of recursion found and the vector is printed due to no more combination like this
                Print(vector);
            }
            else
            {
                for (int i = 1; i <= vector.Length; i++)
                {
                    vector[index] = i;
                    ExcuteNestedLoops(index - 1, vector);
                }
            }
        }

        private static void Print(int[] vector)
        {
            Console.WriteLine(string.Join(" ", vector)); 
        }
    }
}