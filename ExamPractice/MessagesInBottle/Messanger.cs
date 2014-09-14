// BG CODER: http://bgcoder.com/Contests/Practice/Index/90#0

namespace MessagesInBottle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class Messanger
    {
        private static readonly List<KeyValuePair<char, string>> ciphers = new List<KeyValuePair<char, string>>();

        private static readonly SortedSet<string> solutions = new SortedSet<string>();

        private static string message;

        private static void Main()
        {
            message = Console.ReadLine();
            string cipher = Console.ReadLine();

            char key = char.MinValue;
            var value = new StringBuilder();

            for (int i = 0; i < cipher.Length; i++)
            {
                if (cipher[i] >= 'A' && cipher[i] <= 'Z')
                {
                    if (key != char.MinValue)
                    {
                        ciphers.Add(new KeyValuePair<char, string>(key, value.ToString()));
                        value.Clear();
                    }

                    key = cipher[i];
                }
                else
                {
                    value.Append(cipher[i]);
                }
            }

            if (key != char.MinValue)
            {
                ciphers.Add(new KeyValuePair<char, string>(key, value.ToString()));
                value.Clear();
            }

            Solve(0, new StringBuilder());
            Console.WriteLine(solutions.Count);
            foreach (var solution in solutions)
            {
                Console.WriteLine(solution.ToString());
            }
        }

        private static void Solve(int secretMessageIndex, StringBuilder sb)
        {
            if (secretMessageIndex == message.Length)
            {
                solutions.Add(sb.ToString());
                return;
            }
            foreach (var cipher in ciphers)
            {
                if (message.Substring(secretMessageIndex).StartsWith(cipher.Value))
                {
                    sb.Append(cipher.Key);
                    Solve(secretMessageIndex + cipher.Value.Length, sb);
                    sb.Length--;
                }
            }
        }
    }
}