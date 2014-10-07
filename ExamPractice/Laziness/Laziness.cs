// http://bgcoder.com/Contests/Practice/Index/96#0
namespace Laziness
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Laziness
    {
        static void Main()
        {
            int numbersCount = int.Parse(Console.ReadLine());
            string[] indexes = Console.ReadLine().Split(' ');

            var start = int.Parse(indexes[0]);
            var end = int.Parse(indexes[1]);

            var numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();

            numbers.Sort(start, (end - start + 1), new Comparator());

            var result = new StringBuilder();
            result.Append(string.Join(" ", numbers));

            Console.WriteLine(result.ToString().Trim());
        }
    }

    public struct Comparator : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
    }
}