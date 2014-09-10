namespace BinaryPasswords
{
    using System;
    using System.Linq;

    public class PasswordChecker
    {
        private static readonly char UnknownDigitSymbol = '*';

        public ulong GetPasswordsCountByPattern(string passwordPattern)
        {
            ulong asteriksCount = 1;

            for (int i = 0; i < passwordPattern.Length; i++)
            {
                if (passwordPattern[i] == UnknownDigitSymbol)
                {
                    asteriksCount *= 2;
                }
            }

            return asteriksCount;
        }
    }
}