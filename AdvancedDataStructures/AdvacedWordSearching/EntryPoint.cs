namespace AdvacedWordSearching
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    internal class EntryPoint
    {
        public const int wordsToAdd = 1000000;
        public const int wordsToSearch = 1000000;

        public static Random rnd = new Random();

        public static void Main()
        {
            var sw = new Stopwatch();

            var trie = new Trie();

            for (int i = 0; i < wordsToAdd; i++)
            {
                string word = GetRandomWord();
                sw.Start();
                trie.Add(word);
                sw.Stop();
            }

            Console.WriteLine("Added {0} words for {1} time", wordsToAdd, sw.Elapsed);

            sw.Reset();
            for (int i = 0; i < wordsToSearch; i++)
            {
                string word = GetRandomWord();
                sw.Start();
                trie.GetWordOccurance(word);
                sw.Stop();
            }

            Console.WriteLine("Found {0} words for {1} time", wordsToSearch, sw.Elapsed);

            Console.WriteLine("Most common word: {0}",trie.GetMostCommonWord());
        }

        public static string GetRandomWord()
        {
            char[] newWord = new char[rnd.Next(5, 20)];
            for (int i = 0; i < newWord.Length; i++)
            {
                newWord[i] = ((char)rnd.Next(65, 91));
            }

            return new string(newWord);
        }
    }
}