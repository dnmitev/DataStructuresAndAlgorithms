// http://bgcoder.com/Contests/Practice/Index/133#5
namespace Words
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    class Words
    {
        static Dictionary<char, HashSet<string>> allWords = new Dictionary<char, HashSet<string>>();

        static void Main()
        {
            PrepareDictionary();
            GetTextInput();
            ProcessWord();
        }

        private static void ProcessWord()
        {
            int wordsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < wordsCount; i++)
            {
                var word = Console.ReadLine();
                var loweredWord = word.ToLower();
                
                var currentSet = new HashSet<string>(allWords[loweredWord[0]]);

                for (int j = 1; j < loweredWord.Length; j++)
                {
                    currentSet.IntersectWith(allWords[loweredWord[j]]);
                }

                Console.WriteLine("{0} -> {1}", word, currentSet.Count);
            }
        }

        private static void GetTextInput()
        {
            int textLinesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < textLinesCount; i++)
            {
                var line = Console.ReadLine().ToLower();
                var word = new StringBuilder();
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] >= 'a' && line[j] <= 'z')
                    {
                        word.Append(line[j]);
                    }
                    else if (word.Length > 0)
                    {
                        AddWord(word.ToString());
                        word.Clear();
                    }
                }

                if (word.Length > 0)
                {
                    AddWord(word.ToString());
                }
            }
        }

        private static void AddWord(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                allWords[word[i]].Add(word);
            }
        }

        private static void PrepareDictionary()
        {
            for (char symbol = 'a'; symbol <= 'z'; symbol++)
            {
                allWords[symbol] = new HashSet<string>();
            }
        }
    }
}