namespace GirlsGoneWild
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class GirlsGoneWild
    {
        private static SortedSet<string> results = new SortedSet<string>();

        private static List<List<int>> combinationsOfPeople = new List<List<int>>();
        private static List<List<char>> combinationsOfShirts = new List<List<char>>();

        private static int[] combinations;
        private static int numberOfPeople;
        private static char[] shirtTypes;

        static void Main()
        {
            combinations = new int[int.Parse(Console.ReadLine())];
            shirtTypes = Console.ReadLine().ToCharArray().OrderBy(x => x).ToArray();
            numberOfPeople = int.Parse(Console.ReadLine());

            GenerateCombinationsNoRepetitions(0, 0, combinations, (x) => combinationsOfPeople.Add(new List<int>(x)));
            combinations = new int[shirtTypes.Length];
            GenerateCombinationsNoRepetitions(0, 0, combinations, (x) =>
            {
                var list = new List<char>();
                for (int i = 0; i < numberOfPeople; i++)
                {
                    list.Add(shirtTypes[x[i]]);
                }
                combinationsOfShirts.Add(list);
            });

            foreach (var peopleCombo in combinationsOfPeople)
            {
                foreach (var shirtsCombo in combinationsOfShirts)
                {
                    var shirtsPerm = new List<char>(shirtsCombo);
                    PermuteWithReps(shirtsPerm,0,shirtsPerm.Count,(x) => MergeResult(peopleCombo,x));
                }
            }

            Console.WriteLine(results.Count);
            foreach (var result in results)
            {
                Console.WriteLine(result); 
            }
        }

        private static void MergeResult(List<int> numbers, List<char> symbols)
        {
            var output = new StringBuilder();

            for (int i = 0; i < symbols.Count; i++)
            {
                output.Append(numbers[i]);
                output.Append(symbols[i]);
                output.Append("-");
            }

            output.Length--;

            results.Add(output.ToString());
        }

        static void GenerateCombinationsNoRepetitions(int index, int start, int[] arr, Action<int[]> action)
        {
            if (index >= numberOfPeople)
            {
                action(arr);
            }
            else
            {
                for (int i = start; i < arr.Length; i++)
                {
                    arr[index] = i;
                    GenerateCombinationsNoRepetitions(index + 1, i + 1, arr, action);
                }
            }
        }

         private static void PermuteWithReps(List<char> arr,int start ,int n, Action<List<char>> action)
         {
             action(arr);

             for (int left = n - 2; left >= start; left--)
             {
                 for (int right = left + 1; right < n; right++)
                 {
                     if (arr[left] != arr[right])
                     {
                         var oldValue = arr[left];
                         arr[left] = arr[right];
                         arr[right] = oldValue;

                         PermuteWithReps(arr, left + 1, n, action);
                     }
                 }

                 // Undo all modifications done by the
                 // previous recursive calls and swaps
                 var firstElement = arr[left];
                 for (int i = left; i < n - 1; i++)
                 {
                     arr[i] = arr[i + 1];
                 }

                 arr[n - 1] = firstElement;
             }
         }
    }
}