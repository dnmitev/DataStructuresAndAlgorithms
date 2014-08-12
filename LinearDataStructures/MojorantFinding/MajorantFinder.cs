// 08. * The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. Write a program to 
// find the majorant of given array (if exists). Example: {2, 2, 3, 3, 2, 3, 4, 3, 3} -> 3

namespace MojorantFinding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class MajorantFinder
    {
        private static void Main()
        {
            var list = new List<int> { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            var majorant = GetMajorant(list);
            Console.WriteLine("List: {0}", string.Join(", ", list));

            string output = majorant == int.MinValue ? "There is no majorant" : string.Format("The mojarant is {0}", majorant);
            Console.WriteLine(output);
        }

        private static int GetMajorant(List<int> list)
        {
            int majorant = int.MinValue;

            // sorted list means less operations count
            list.Sort();

            for (int i = 0; i < list.Count / 2; i++)
            {
                int counter = 1;
                while (list[i] == list[i + 1])
                {
                    i++;
                    counter++;
                }

                if (counter > list.Count / 2)
                {
                    majorant = list[i];
                }
            }

            return majorant;
        }
    }
}