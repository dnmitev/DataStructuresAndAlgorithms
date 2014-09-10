namespace SetOfBalls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    class EntryPoint
    {
        static void Main()
        {
            string userInput = Console.ReadLine();
            var variations = new VariationsCounter();

            var result = variations.GetVariations(userInput);

            Console.WriteLine(result);
        }
    }
}