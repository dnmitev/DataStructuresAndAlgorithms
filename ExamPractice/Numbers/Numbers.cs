namespace Numbers
{
    using System;
    using System.Linq;

    internal class Numbers
    {
        private static void Main()
        {
            var input = Console.ReadLine().Split(' ');

            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            int p = int.Parse(input[2]);
            int q = int.Parse(input[3]);

            int counter = 0;

            for (int i = a; i <= b; i++)
            {
                if (i % p == q)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}