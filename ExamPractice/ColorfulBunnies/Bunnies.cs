// BG CODER:  http://bgcoder.com/Contests/Practice/Index/132#1
namespace ColorfulBunnies
{
    using System;
    using System.Collections.Generic;

    class Bunnies
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var bunnies = new Dictionary<int, int>();
            int totalCount = 0;

            for (int i = 0; i < n; i++)
            {
                int bunnyAnswer = int.Parse(Console.ReadLine());

                if (!bunnies.ContainsKey(bunnyAnswer))
                {
                    bunnies[bunnyAnswer] = 0;
                }

                bunnies[bunnyAnswer]++;
            }

            var otherBunnies = new Dictionary<int,int>(bunnies);

            foreach (var bunny in bunnies)
            {
                while (otherBunnies[bunny.Key] > 0)
                {
                    otherBunnies[bunny.Key] -= (bunny.Key + 1);
                    totalCount += (bunny.Key + 1);
                }
            }


            Console.WriteLine(totalCount);
        }
    }
}