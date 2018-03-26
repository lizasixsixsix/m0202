using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using m0202;

namespace m0202.Tests
{
    [TestClass]
    public class CustomIntParserTests
    {
        [TestMethod]
        [DataRow("77", 77)]
        public void Parse_CorrectString_ExpectedResult(
            string str, int number)
        {
            Assert.AreEqual(number, CustomIntParser.Parse(str));
        }
    }
}
