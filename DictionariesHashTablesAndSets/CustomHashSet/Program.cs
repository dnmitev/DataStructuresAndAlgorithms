// 05. Implement the data structure "set" in a class HashedSet<T> using your class HashTable<K,T> to hold the elements. Implement 
// all standard set operations like Add(T), Find(T), Remove(T), Count, Clear(), union and intersect.

namespace CustomHashSet
{
    using System;
    using System.Linq;
    using CustomHashTable;

    public class Program
    {
        private static void Main()
        {
            var set = new CustomHashSet<string>();

            set.Add("Tozi");
            set.Add("Onzi");
            set.Add("Vrachaneca");

            // Find
            Console.WriteLine(set.Find("Tozi"));
            Console.WriteLine(set.Find("Onzi"));
            Console.WriteLine(set.Find("Ivan"));

            // Remove and Count
            Console.WriteLine("Elements in the table: {0}", set.Count);
            Console.WriteLine("Removing element...");
            set.Remove("Pesho");
            Console.WriteLine("Elements in the table: {0}", set.Count);

            // Clear
            Console.WriteLine("Clearing the table...");
            set.Clear();
            Console.WriteLine("Elements in the table: {0}", set.Count);
        }
    }
}