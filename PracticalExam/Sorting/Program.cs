using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static int max = 0;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int k = int.Parse(Console.ReadLine());

            BubbleSort(numbers);
            Console.WriteLine(max);
        }

        private static void BubbleSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length-1; i++)
            {
                for (int j = i; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[i])
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;

                        max++;
                    }
                }
            }
        }
    }
}
