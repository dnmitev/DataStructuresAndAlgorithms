// BG CODER: http://bgcoder.com/Contests/Practice/Index/89#0
namespace Frames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class Frames
    {
        private static readonly SortedSet<string> allPerms = new SortedSet<string>();

        private static void Main()
        {
            int framesCount = int.Parse(Console.ReadLine());
            Frame[] frames = new Frame[framesCount];

            for (int i = 0; i < framesCount; i++)
            {
                int[] frameData = Console.ReadLine()
                                         .Split(' ')
                                         .Select(x => int.Parse(x))
                                         .ToArray();

                frames[i] = new Frame(frameData[0], frameData[1]);
            }

            GeneratePermutations(frames, 0);

            var result = new StringBuilder();
            foreach (var perm in allPerms)
            {
                result.AppendLine(perm);
            }

            Console.WriteLine(allPerms.Count);
            Console.WriteLine(result.ToString().Trim());
        }

        private static void GeneratePermutations(Frame[] arr, int k)
        {
            if (k >= arr.Length)
            {
                string perm = string.Join(" | ", arr.Select(x => x.ToString()));
                allPerms.Add(perm);
            }
            else
            {
                GeneratePermutations(arr, k + 1);
                SwapFrame(ref arr[k]);
                GeneratePermutations(arr, k + 1);
                SwapFrame(ref arr[k]);

                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, k + 1);
                    SwapFrame(ref arr[k]);
                    GeneratePermutations(arr, k + 1);
                    SwapFrame(ref arr[k]);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }

        private static void SwapFrame(ref Frame frame)
        {
            int oldWidth = frame.Width;
            frame.Width = frame.Height;
            frame.Height = oldWidth;
        }
    }
}