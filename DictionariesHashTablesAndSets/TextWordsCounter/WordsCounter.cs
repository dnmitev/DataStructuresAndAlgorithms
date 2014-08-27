// Write a program that counts how many times each word from given text file words.txt appears in it. The character casing differences
// should be ignored. The result words should be ordered by their number of occurrences in the text. 

namespace TextWordsCounter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class WordsCounter
    {
        static void Main()
        {
            var reader = new StreamReader(@"..\..\input.txt", Encoding.UTF8);
            var wordsCounter = new Dictionary<string, int>();

            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] words = line.Split(new char[] { ' ', ',', '-', '!', '?', '.', ';' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < words.Length; i++)
                    {
                        var key = words[i].ToLower();
                        if (!wordsCounter.ContainsKey(key))
                        {
                            wordsCounter[key] = 0;
                        }

                        wordsCounter[key]++;
                    }

                    line = reader.ReadLine();
                }
            }

            foreach (var word in wordsCounter)
            {
                Console.WriteLine("{0} -> counted {1} times", word.Key, word.Value);
            }
        }
    }
}