// http://bgcoder.com/Contests/Practice/Index/96#3
namespace CubicRoot
{
    using System;
    using System.Numerics;

    class CubicRoot
    {
        static void Main()
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());

            BigInteger left = 0;
            BigInteger right = number;
            BigInteger result = (right - left) / 2 + left;

            var currentPower = result * result * result;
            while (currentPower != number)
            {
                if (currentPower < number)
                {
                    left = result;
                }
                else if (currentPower > number)
                {
                    right = result;
                }

                result = (right - left) / 2 + left;

                currentPower = result * result * result;
            }

            Console.WriteLine(result);
        }
    }
}