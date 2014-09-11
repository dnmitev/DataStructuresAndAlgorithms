namespace KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class EntryPoint
    {
        private static void Main()
        {
            int capacity = int.Parse(Console.ReadLine());
            int itemsCount = int.Parse(Console.ReadLine());

            List<Item> items = new List<Item>();

            for (int i = 0; i < itemsCount; i++)
            {
                string input = Console.ReadLine();

                string[] itemData = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var item = new Item()
                {
                    Name = itemData[0],
                    Weight = int.Parse(itemData[1]),
                    Value = int.Parse(itemData[2])
                };

                items.Add(item);
            }

            int[,] dpTable = new int[itemsCount + 1, capacity + 1];
            int[,] backtracking = new int[itemsCount + 1, capacity + 1];

            for (int i = 1; i <= itemsCount; i++)
            {
                Item currentItem = items[i - 1];

                for (int j = 1; j < capacity; j++)
                {
                    int notUsedValue = dpTable[i - 1, j];
                    int usedValue = 0;

                    if (j - currentItem.Weight >= 0)
                    {
                        usedValue = dpTable[i - 1, j - currentItem.Weight] + currentItem.Value;
                    }

                    if (usedValue >= notUsedValue && usedValue != 0)
                    {
                        dpTable[i, j] = usedValue;
                        backtracking[i, j] = j - currentItem.Weight;
                    }
                    else
                    {
                        dpTable[i, j] = notUsedValue;
                    }
                }
            }

            int max = 0;
            int index = 0;

            for (int i = 0; i < capacity + 1; i++)
            {
                if (dpTable[itemsCount, i] >= max)
                {
                    max = dpTable[itemsCount, i];
                    index = i;
                }
            }

            for (int i = itemsCount; i > 0; i--)
            {
                if (dpTable[i, index] != dpTable[i - 1, index])
                {
                    Console.WriteLine(items[i - 1].Name);
                    index = backtracking[i, index];
                }
            }

            Console.WriteLine(max);
        }
    }
}