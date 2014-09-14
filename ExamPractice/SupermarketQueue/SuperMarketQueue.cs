
namespace SupermarketQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    class SuperMarketQueue
    {
        static BigList<string> queue = new BigList<string>();
        static Dictionary<string, int> nameCounts = new Dictionary<string, int>();

        static void Main()
        {
            while (true)
            {
                string[] commandLine = Console.ReadLine().Split(' ');
                switch (commandLine[0])
                {
                    case "End":
                        {
                            return;
                        }
                    case "Append":
                        {
                            string name = commandLine[1];
                            queue.Add(name);
                            Console.WriteLine("OK");

                            if (!nameCounts.ContainsKey(name))
                            {
                                nameCounts[name] = 0;
                            }

                            nameCounts[name]++;

                            break;
                        }
                    case "Insert":
                        {
                            int position = int.Parse(commandLine[1]);
                            string name = commandLine[2];

                            if (position < 0 || position > queue.Count)
                            {
                                Console.WriteLine("Error");

                                break;
                            }

                            queue.Insert(position, name);
                            Console.WriteLine("OK");

                            if (!nameCounts.ContainsKey(name))
                            {
                                nameCounts[name] = 0;
                            }

                            nameCounts[name]++;

                            break;
                        }
                    case "Find":
                        {
                            string targetName = commandLine[1];
                            Console.WriteLine(nameCounts.ContainsKey(targetName) ? nameCounts[targetName] : 0);
                            break;
                        }
                    case "Serve":
                        {
                            int count = int.Parse(commandLine[1]);

                            if (count > queue.Count)
                            {
                                Console.WriteLine("Error");

                                break;
                            }

                            var sb = new StringBuilder();

                            while (count > 0)
                            {
                                count--;
                                sb.Append(queue[0] + " ");
                                nameCounts[queue[0]]--;
                                queue.Remove(queue[0]);
                            }

                            Console.WriteLine(sb.ToString().Trim());
                            break;
                        }
                    default:
                        throw new ArgumentException("Not specified command");
                }
            }
        }
    }
}
