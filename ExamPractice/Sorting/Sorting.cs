// http://bgcoder.com/Contests/Practice/Index/133#0
namespace Sorting
{
    using System;
    using System.Linq;
    using System.Text;

    class Sorting
    {
        static void Main()
        {
            var data = Console.ReadLine().Split(' ');

            var n = uint.Parse(data[0]);
            var x = uint.Parse(data[1]);

            var numbers = Console.ReadLine().Split(' ').Select(p => uint.Parse(p)).ToList();

            numbers = numbers
                             .Select(num => num)
                             .OrderBy(num => num)
                             .OrderBy(num => num % x)
                             .ToList();

            var result = new StringBuilder();
            foreach (var item in numbers)
            {
                result.Append(item);
                result.Append(" ");
            }

           Console.WriteLine(result.ToString().Trim());
        }
    }
}