// http://bgcoder.com/Contests/Practice/Index/96#2
namespace Algograms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Algograms
    {
        static void Main()
        {
            var words = new SortedSet<string>();
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "-1")
                {
                    break;
                }

                line = string.Join("", line.OrderBy(c => c));

                words.Add(line);
            }

            Console.WriteLine(words.Count);
        }
    }
}