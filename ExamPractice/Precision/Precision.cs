namespace Precision
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Precision
    {
        static void Main()
        {
            int maxDenominator = int.Parse(Console.ReadLine());
            string decNum = Console.ReadLine();
        }
    }

    struct Fraction
    {
        private string decimalNum;

        public Fraction(string decNum)
        {
            this.decimalNum = decNum;
        }

        public int Nominator { get; set; }

        public int Denominator { get; set; }

        public decimal Decimal
        {
            get
            {
                return Nominator / Denominator;
            }
        }

        public int Precision
        {
            get
            {
                int count = 0;
                string precision = decimalNum.ToString();
                for (int i = 0; i < decimalNum.Length; i++)
                {
                    if (decimalNum[i] == precision[i])
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }

                return count;
            }
        }
    }
}