namespace SetOfBalls.Tests
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Numerics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CombinationCounterTest
    {
        [TestMethod]
        public void GetVariationsTest()
        {
            var variations = new VariationsCounter();

            var dir = new DirectoryInfo("../../Tests");
            var filesCount = dir.GetFiles().Count() / 2;

            var inputFilePath = "../../Tests/test.{0}.in.txt";
            var outputFilePath = "../../Tests/test.{0}.out.txt";

            for (int i = 1; i <= filesCount; i++)
            {
                var input = new StreamReader(string.Format(inputFilePath, i.ToString("D3"))).ReadToEnd();
                var output = new StreamReader(string.Format(outputFilePath, i.ToString("D3"))).ReadToEnd();

                var expectedAnswer = BigInteger.Parse(output);

                var answer = variations.GetVariations(input);

                Assert.AreEqual(expectedAnswer, answer, string.Format("i = {2} -> {0} != {1}", expectedAnswer, answer, i));
            }
        }
    }
}