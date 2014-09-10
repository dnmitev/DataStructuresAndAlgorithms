namespace BinaryPasswords.Tests
{
    using System;
    using System.IO;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CheckerTests
    {
        [TestMethod]
        public void InputOutputTests()
        {
            var checker = new PasswordChecker();

            var dir = new DirectoryInfo("../../Tests");
            var filesCount = dir.GetFiles().Count() / 2;

            var inputFilePath = "../../Tests/test.{0}.in.txt";
            var outputFilePath = "../../Tests/test.{0}.out.txt";

            for (int i = 1; i <= filesCount; i++)
            {
                var input = new StreamReader(string.Format(inputFilePath, i.ToString("D3"))).ReadToEnd();
                var output = new StreamReader(string.Format(outputFilePath, i.ToString("D3"))).ReadToEnd();

                var expectedAnswer = ulong.Parse(output);

                var answer = checker.GetPasswordsCountByPattern(input);

                Assert.AreEqual(expectedAnswer, answer);
            }
        }
    }
}