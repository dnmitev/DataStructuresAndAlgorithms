namespace Task01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Election
    {
        static int k;
        //static int n;

        static int seats;
        static int partiesCount;
        static int[] seatsByParty;

        static int[] arr;
        static int result = 0;

        static void Main()
        {
            seats = int.Parse(Console.ReadLine());
            partiesCount = int.Parse(Console.ReadLine());

            seatsByParty = new int[partiesCount];
            for (int i = 0; i < partiesCount; i++)
            {
                seatsByParty[i] = int.Parse(Console.ReadLine());
                if (seatsByParty[i] >= seats)
                {
                    result++;
                }
            }

            Array.Sort(seatsByParty);

            for (int i = 2; i < partiesCount; i++)
            {
                k = i;
                arr = new int[k];
                GenerateCombinationsNoRepetitions(0, 0);
            }

            if (seatsByParty.Sum() >= seats)
            {
                result++;
            }

            Console.WriteLine(result);
        }

        static void GenerateCombinationsNoRepetitions(int index, int start)
        {
            if (index >= k)
            {
                return;
            }
            else
            {
                for (int i = start; i < partiesCount; i++)
                {
                    arr[index] = i;

                    if (arr.Select(a => a=i).Count() > 1)
                    {
                        continue;
                    }

                    int sum = 0;
                    for (int p = 0; p < arr.Length; p++)
                    {
                        sum += seatsByParty[arr[p]];
                    }

                    Console.WriteLine(sum);
                    if (sum >= seats)
                    {
                        result++;
                        continue;
                    }

                    GenerateCombinationsNoRepetitions(index + 1, i + 1);
                }
            }
        }

        static void PrintVariations()
        {
            int sum = 0;
            Console.Write("(" + String.Join(", ", arr) + ") --> ( ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(seatsByParty[arr[i]] + " ");
                sum += seatsByParty[arr[i]];
            }
            Console.WriteLine(")={0}", sum);
        }
    }
}