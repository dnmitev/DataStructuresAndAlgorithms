namespace Task03
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Maps
    {
        static int n = 3;
        static int k;
        static string[] dirs =
        {
            "L", "R", "S"
        };
        static int[] arr;

        static List<string> variations = new List<string>();
        
        static void Main()
        {
            string map = Console.ReadLine();
            var maps = new SortedSet<string>();

            int asterisksCount = 0;

            var sb = new StringBuilder();


            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] == '*')
                {
                    asterisksCount++;
                }
            }
            int count = asterisksCount > 0 ? (int)Math.Pow(3, asterisksCount) : 1;
            k = asterisksCount;
            arr = new int[k];
            GenerateVariationsWithRepetitions(0);
            for (int i = 0; i < variations.Count; i++)
            {
                sb.Clear();
                int l = 0;
                for (int j = 0; j < map.Length; j++)
                {
                    if (map[j] != '*')
                    {
                        sb.Append(map[j]);
                    }
                    else
                    {
                        sb.Append(variations[i][l]);
                        l++;
                    }
                }

                maps.Add(sb.ToString());
            }

            var result = new StringBuilder();
            foreach (var m in maps)
            {
                result.AppendLine(m);
            }

            Console.WriteLine(count);
            Console.WriteLine(result.ToString().Trim());
        }

        static void GenerateVariationsWithRepetitions(int index)
        {
            if (index >= k)
            {
                //PrintVariations();
                var sb = new StringBuilder();
                for (int i = 0; i < arr.Length; i++)
                {
                    sb.Append(dirs[arr[i]]);
                }
                variations.Add(sb.ToString());
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    arr[index] = i;
                    GenerateVariationsWithRepetitions(index + 1);
                }
            }
        }

        static void PrintVariations()
        {
            Console.Write("(" + String.Join(", ", arr) + ") --> ( ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(dirs[arr[i]] + " ");
            }
            Console.WriteLine(")");
        }
    }
}