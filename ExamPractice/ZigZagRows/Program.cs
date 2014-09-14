// BG CODER: http://bgcoder.com/Contests/Practice/Index/132#4

namespace ZigZagRows
{
    using System;

    internal class Program
    {
        private static int n;
        private static int k;

        private static int[] objects;

        private static int[] arr;
        private static bool[] used;

        private static int zigZagRowsCount = 0;

        private static void Main()
        {
            string[] inputData = Console.ReadLine().Split(' ');

            n = int.Parse(inputData[0]);
            k = int.Parse(inputData[1]);

            objects = new int[n];

            arr = new int[k];
            used = new bool[n];

            for (int i = 0; i < n; i++)
            {
                objects[i] = i;
            }

            GenerateVariationsNoRepetitions(0);

            Console.WriteLine(zigZagRowsCount);
        }

        private static void GenerateVariationsNoRepetitions(int index)
        {
            if (index >= k)
            {
                //PrintVariations();
                if (IsZigZagRow())
                {
                    zigZagRowsCount++;
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = i;
                        GenerateVariationsNoRepetitions(index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        //static void PrintVariations()
        //{
        //    Console.Write("(" + String.Join(", ", arr) + ") --> ( ");
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        Console.Write(objects[arr[i]] + " ");
        //    }
        //    Console.WriteLine(")");
        //}
        private static bool IsZigZagRow()
        {
            bool isZigZag = true;
            for (int i = 1; i < arr.Length; i++)
            {
                if ((i & 1) != 0)
                {
                    if (arr[i] < arr[i - 1])
                    {
                        isZigZag = true;
                    }
                    else
                    {
                        isZigZag = false;
                        break;
                    }
                }
                else
                {
                    if (arr[i] > arr[i - 1])
                    {
                        isZigZag = true;
                    }
                    else
                    {
                        isZigZag = false;
                        break;
                    }
                }
            }

            return isZigZag;
        }
    }
}