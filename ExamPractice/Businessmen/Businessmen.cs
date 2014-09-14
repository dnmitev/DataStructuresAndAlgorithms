// BG CODER: http://bgcoder.com/Contests/Practice/Index/89#4

namespace Businessmen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Businessmen
    {
        private static int n;
        private static long[] cache;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            cache = new long[n + 1];

            GetHandshakeCount(n);

            Console.WriteLine(cache[n]);
        }

        private static long GetHandshakeCount(int n)
        {
            if (cache[n] == 0)
            {
                if (n == 0)
                {
                    cache[n] = 1;
                }

                if (n == 1)
                {
                    cache[n] = 0;
                }

                for (int i = 2; i < n + 1; i += 2)
                {
                    cache[n] += GetHandshakeCount(i - 2) * GetHandshakeCount(n - i);
                }
            }

            return cache[n];
        }
    }
}