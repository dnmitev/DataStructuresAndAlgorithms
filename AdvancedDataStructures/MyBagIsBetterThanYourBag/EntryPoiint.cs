// 02. Write a program to read a large collection of products (name + price) and efficiently find the first 20 products in 
// the price range [a…b]. Test for 500 000 products and 10 000 price searches.
// Hint: you may use OrderedBag<T> and sub-ranges

namespace MyBagIsBetterThanYourBag
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using Wintellect.PowerCollections;

    internal class EntryPoiint
    {
        private static void Main()
        {
            OrderedBag<Product> catalog = new OrderedBag<Product>();
            Random randomGenerator = new Random();
            Stopwatch sw = new Stopwatch();
            TimeSpan ts = new TimeSpan();

            sw.Start();
            for (int i = 0; i < 500000; i++)
            {
                var number = randomGenerator.Next(0, int.MaxValue);
                catalog.Add(new Product
                {
                    Name = string.Format("Pencho{0}", number),
                    Price = (decimal)Math.Sqrt(number)
                });
            }
            sw.Stop();
            ts = sw.Elapsed;

            Console.WriteLine("Time elapsed for adding: {0}s {1}ms", ts.Seconds, ts.Milliseconds);

            sw.Reset();

            sw.Start();
            var productsInPriceRange = catalog.FindAll(p => p.Price > 1000 && p.Price < 5000);
            sw.Stop();
            ts = sw.Elapsed;

            Console.WriteLine("Time elapsed for searching: {0}s {1}ms", ts.Seconds, ts.Milliseconds);

            sw.Reset();

            sw.Start();
            for (int i = 0; i < 10000; i++)
            {
                int min = randomGenerator.Next(0, 1000);
                int max = randomGenerator.Next(1000, int.MaxValue);
                productsInPriceRange = catalog.FindAll(p => p.Price > min && p.Price < max);
            }
            sw.Stop();
            ts = sw.Elapsed;
            Console.WriteLine("Time elapsed for searching 10 000 times in 500 000 records: {0}s {1}ms", ts.Seconds, ts.Milliseconds);

            var selection = productsInPriceRange.Take(20);

            foreach (var product in selection)
            {
                Console.WriteLine("{0} -> ${1}", product.Name, product.Price);
            }
        }
    }
}