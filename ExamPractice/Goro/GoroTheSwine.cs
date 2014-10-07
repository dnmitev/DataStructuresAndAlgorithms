// http://bgcoder.com/Contests/Practice/Index/96#1
namespace Goro
{
    using System;

    class GoroTheSwine
    {
        static void Main()
        {
            int firstDice = int.Parse(Console.ReadLine());
            int secondDice = int.Parse(Console.ReadLine());
            int thirdDice = int.Parse(Console.ReadLine());

            int choicesCount = int.Parse(Console.ReadLine());

            int totalPoints = 0;

            while (choicesCount > 0)
            {
                if (firstDice >= secondDice && firstDice >= thirdDice && firstDice >= 1)
                {
                    totalPoints += firstDice;
                    firstDice--;
                }
                else if (secondDice >= firstDice && secondDice >= thirdDice && secondDice >= 1)
                {
                    totalPoints += secondDice;
                    secondDice--;
                }
                else if (thirdDice >= firstDice && thirdDice >= secondDice && thirdDice >= 1)
                {
                    totalPoints += thirdDice;
                    thirdDice--;
                }

                choicesCount--;
            }

            Console.WriteLine(totalPoints);
        }
    }
}