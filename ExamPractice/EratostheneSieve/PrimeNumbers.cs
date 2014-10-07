// http://bgcoder.com/Contests/Practice/Index/96#4
namespace EratostheneSieve
{
    using System;

    class PrimeNumbers
    {
        static void Main()
        {
            int maxNum = int.Parse(Console.ReadLine());

            bool[] isScratched = new bool[maxNum];
            var result = 0;
            for (int x = 2; x <= Math.Sqrt(maxNum); x++)
            {
                if (!isScratched[x])
                {
                    for (int y = 2; y <= maxNum / x; y++)
                    {
                        if (!isScratched[x*y])
                        {
                            isScratched[x*y] = true;
                            result = x * y;
                        }
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}