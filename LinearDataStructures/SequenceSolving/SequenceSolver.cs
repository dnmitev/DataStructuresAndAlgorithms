// 09.We are given the following sequence:
//  S1 = N;
//  S2 = S1 + 1;
//  S3 = 2*S1 + 1;
//  S4 = S1 + 2;
//  S5 = S2 + 1;
//  S6 = 2*S2 + 1;
//  S7 = S2 + 2;
//  ...
//  Using the Queue<T> class write a program to print its first 50 members for given N.
//  Example: N=2  2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...

namespace SequenceSolving
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class SequenceSolver
    {
        private static void Main()
        {
            int n = 2;
            int membersCount = 50;
            int counter = 0;

            Queue<int> sequence = new Queue<int>();

            sequence.Enqueue(n);

            Console.Write("S=");
            while (sequence.Count > 0)
            {
                counter++;
                int current = sequence.Dequeue();

                Console.Write("{0}, ", current);
                if (counter == membersCount)
                {
                    Console.WriteLine();
                    break;
                }

                sequence.Enqueue(current + 1);
                sequence.Enqueue(2 * current + 1);
                sequence.Enqueue(current + 2);
            }
        }
    }
}