// 02. A large trade company has millions of articles, each described by barcode, vendor, title and price. Implement a data \
// structure to store them that allows fast retrieval of all articles in given price range [x…y].
// Hint: use OrderedMultiDictionary<K,T> from Wintellect's Power Collections for .NET. 

namespace Articles
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    internal class EntryPoint
    {
        private static void Main()
        {
            OrderedMultiDictionary<decimal, Article> articles = new OrderedMultiDictionary<decimal, Article>(true);

            //  To test with 1 500 000 mil Articles download 100mb file: 
            //  http://www.4shared.com/rar/kBeJdHzA/data1500000.html
            //  http://www.filedropper.com/data1500000
            var sw = new Stopwatch();
            sw.Start();
            var reader = new StreamReader(@"..\..\data1500000.csv", Encoding.UTF8);
            using (reader)
            {
                string line = reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    var data = line.Split(new char[] { ',', '"' }, StringSplitOptions.RemoveEmptyEntries);
                    var barcode = data[0];
                    var vendor = data[1];
                    var title = data[2];
                    var price = decimal.Parse(data[3]);

                    var article = new Article(barcode, vendor, title, price);

                    if (!articles.ContainsKey(article.Price))
                    {
                        articles[article.Price].Add(article);
                    }
                    else
                    {
                        articles.Add(article.Price, article);
                    }
                }
            }
            sw.Stop();

            Console.WriteLine("Time elapsed to store 1 500 000 reci=ords: {0}",sw.Elapsed);

            sw.Reset();
            sw.Start();
            var filteredArticles = articles.Range(1000, true, 1000000, true);
            Console.WriteLine("Records found: {0}", filteredArticles.Count);
            sw.Stop();

            Console.WriteLine("Time elapsed for searching: {0}",sw.Elapsed);
        }
    }
}