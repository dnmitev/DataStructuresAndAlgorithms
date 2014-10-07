// http://bgcoder.com/Contests/Practice/Index/133#3
namespace JedyKnightMeditation
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Jedys
    {
        static void Main()
        {
            int jedysCount = int.Parse(Console.ReadLine());

            string[] jedys = Console.ReadLine().Split(' ');

            var masters = new Queue<string>();
            var knights = new Queue<string>();
            var padawans = new Queue<string>();
            for (int i = 0; i < jedys.Length; i++)
            {
                if (jedys[i].StartsWith("m"))
                {
                    masters.Enqueue(jedys[i]);
                }
                else if (jedys[i].StartsWith("k"))
                {
                    knights.Enqueue(jedys[i]);
                }
                else
                {
                    padawans.Enqueue(jedys[i]);
                }
            }

            var result = new StringBuilder();

            result.Append(string.Join(" ", masters));
            result.Append(" ");
            result.Append(string.Join(" ", knights));
            result.Append(" ");
            result.Append(string.Join(" ", padawans));

            Console.WriteLine(result.ToString());
        }
    }
}