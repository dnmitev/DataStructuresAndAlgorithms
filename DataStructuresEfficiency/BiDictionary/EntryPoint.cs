// 03. Implement a class BiDictionary<K1,K2,T> that allows adding triples {key1, key2, value} and fast search by key1, key2 or by 
// both key1 and key2. Note: multiple values can be stored for given key.

namespace BiDictionary
{
    using System;
    using System.Linq;

    internal class EntryPoint
    {
        private static void Main()
        {
            var biDict = new BiDictionary<int, string, string>();

            biDict.Add(100, "kila", "rakia");
            biDict.Add(200, "jeni", "da imam");
            biDict.Add(300, "noshti", "nagradeni");
            biDict.Add(100, "kila", "ciganin");
            biDict.Add(200, "grozdova", "rakia");

            var filteredByKey1 = biDict.FindByFirstKey(100);
            Console.WriteLine(string.Join(", ", filteredByKey1));

            var filteredByKey2 = biDict.FindBySecondKey("kila");
            Console.WriteLine(string.Join(", ", filteredByKey2));

            var filteredByBothKeys = biDict.FindByBothKeys(100, "kila");
            Console.WriteLine(string.Join(", ", filteredByKey1));
        }
    }
}