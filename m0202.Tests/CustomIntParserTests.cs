using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using m0202;
using m0202.Exceptions;

namespace m0202.Tests
{
    [TestClass]
    public class CustomIntParserTests
    {
        [TestMethod]
        [DataRow("76", 76)]
        [DataRow("-76", -76)]
        [DataRow("0", 0)]
        [DataRow("06", 6)]
        public void Parse_CorrectString_ExpectedResult(
            string str, int number)
        {
            Assert.AreEqual(number, CustomIntParser.Parse(str));
        }

        [TestMethod]
        [DataRow("76i")]
        [DataRow("7 6")]
        [DataRow("7.6")]
        [DataRow("7,6")]
        [ExpectedException(typeof(CustomIntParserException))]
        public void Parse_IncorrectString_ExceptionThrown(
            string str)
        {
            CustomIntParser.Parse(str);
        }
    }
}
