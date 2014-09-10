namespace BinaryPasswords
{
    using System;
    using System.Linq;

    internal class EntryPoint
    {
        private static void Main()
        {
            string passwordPattern = Console.ReadLine();
            var checker = new PasswordChecker();

            ulong asteriksCount = checker.GetPasswordsCountByPattern(passwordPattern);

            Console.WriteLine(asteriksCount);
        }
    }
}