using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDExercises.Tests
{
    [TestClass]
    public class StringCalculatorTest
    {
        [TestMethod]
        public void TestEmptyString()
        {
            StringCalculator test = new StringCalculator();
            // take 0, 1, or 2 numbers and return their sum. For an empty string it will return 0.
            Assert.AreEqual(0, test.Add(""), "We expect 0.");
        }
        [TestMethod]
        public void TestSingleNumber()
        {
            StringCalculator test = new StringCalculator();
            // take single number and return their sum. For an empty string it will return 0.
            Assert.AreEqual(4, test.Add("4"), "We expect 4.");
            Assert.AreEqual(0, test.Add(""), "We expect 0.");

        }

        [TestMethod]
        public void TestMultipleNumbers()
        {
            StringCalculator test = new StringCalculator();
            // take multiple numbers and return their sum. For an empty string it will return 0.
            Assert.AreEqual(3, test.Add("0,3,"), "Comma Delimited, we expect 3.");
            Assert.AreEqual(0, test.Add(",,"), "Comma Delimited, we expect 0.");
            Assert.AreEqual(104, test.Add("3,3,3,5,23,0,67"), "Comma Delimited, we expect 104.");
            Assert.AreEqual(104, test.Add("3\n3\n3\n5\n23\n0\n67"), "New Line Delimited, we expect 104.");

        }

        [TestMethod]
        public void TestMultipleNumbersInArray()
        {
            StringCalculator test = new StringCalculator();
            // take multiple numbers and return their sum. For an empty string it will return 0.
            Assert.AreEqual(3, test.Add(new[] { "", "0", "3" }), "We expect 3.");
            Assert.AreEqual(0, test.Add(new[] { "" }), "We expect 0.");
            Assert.AreEqual(104, test.Add(new[] { "3", "3", "3", "5", "23", "0", "67" }), "We expect 104.");
            Assert.AreEqual(12, test.Add(new[] { "1,2,3", "3,2,1", ",,," }), "We expect 3.");

        }
    }
}