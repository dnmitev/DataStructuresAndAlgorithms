// 02. Write a program that extracts from a given sequence of strings all elements that present in it odd number of times. 
// Example:{C#, SQL, PHP, PHP, SQL, SQL } -> {C#, SQL}

namespace ExtractOddCountedStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class OddStringCounter
    {
        private static void Main()
        {
            string[] input = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            Dictionary<string, int> stringsCount = new Dictionary<string, int>();

            for (int i = 0; i < input.Length; i++)
            {
                var key = input[i];
                if (!stringsCount.ContainsKey(key))
                {
                    stringsCount[key] = 0;
                }

                stringsCount[key]++;
            }

            foreach (var str in stringsCount)
            {
                if (str.Value % 2 != 0)
                {
                    Console.WriteLine("{0} -> {1}", str.Key, str.Value);
                }
            }
        }
    }
}