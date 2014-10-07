// http://bgcoder.com/Contests/Practice/Index/133#2
namespace Tubes
{
    using System;

    class Tubes
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int left = 0;
            int mid = 0;
            int right = 0;

            int[] tubes = new int[n];
            for (int i = 0; i < tubes.Length; i++)
            {
                tubes[i] = int.Parse(Console.ReadLine());
                if (tubes[i] > right)
                {
                    right = tubes[i];
                }
            }

            mid = (right - left) / 2 + left;
            int maxTube = -1;
            int tubesCount = 0;
            while (left <= right)
            {
                tubesCount = 0;
                for (int i = 0; i < n; i++)
                {
                    tubesCount += tubes[i] / mid;
                }

                if (tubesCount >= m)
                {
                    left = mid + 1;
                    maxTube = mid;
                }
                else
                {
                    right = mid - 1;
                }

                mid = (right - left) / 2 + left;
            }

            Console.WriteLine(maxTube);
        }
    }
}