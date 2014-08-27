// 04. Implement the data structure "hash table" in a class HashTable<K,T>. Keep the data in array of lists of key-value pairs 
// (LinkedList<KeyValuePair<K,T>>[]) with initial capacity of 16. When the hash table load runs over 75%, perform resizing to 
// 2 times larger capacity. Implement the following methods and properties: Add(key, value), Find(key)value, Remove( key), 
// Count, Clear(), this[], Keys. Try to make the hash table to support iterating over its elements with foreach.

namespace CustomHashTable
{
    using System;
    using System.Linq;

    public class CustomHashTableDemo
    {
        private static void Main()
        {
            var hashTable = new CustomHashTable<string, int>();

            hashTable.Add("dinko", 1);
            hashTable.Add("spinderman", 2);
            hashTable.Add("gubi", 3);
            hashTable.Add("peshi", 100);

            Console.WriteLine(hashTable.Capacity);
            Console.WriteLine(hashTable.Count);

            Console.WriteLine(hashTable.ContainsKey("gubi"));
            Console.WriteLine(hashTable.ContainsKey("no key"));

            hashTable.Remove("gubi");
            Console.WriteLine(hashTable.ContainsKey("gubi"));

            Console.WriteLine(hashTable.Find("peshi"));
        }
    }
}