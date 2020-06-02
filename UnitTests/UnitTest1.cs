using System;
using System.IO;
using practical_task6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateSequence()
        {
            StreamWriter os = new StreamWriter("output.txt", false);
            Console.SetOut(os);
            Program.CreateSequence(2, 3, -1, 2, -1, out int notLess);
            os.Close();

            int[] resultSequence = { 2, 3, -1, 2, 1, 0 };
            bool result = notLess == 6;

            string[] sequence = new StreamReader("output.txt").ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            result = result && sequence.Length == 6;

            int index = 0;

            foreach(string el in sequence) result = result && int.Parse(el) == resultSequence[index++];

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestIntInput()
        {
            Console.SetIn(new StreamReader("input.txt"));
            double result = 2;

            double input = Program.IntInput(lBound: 0, info: "some info");

            Assert.AreEqual(result, input);
        }
    }
}
