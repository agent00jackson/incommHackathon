using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IncommChallengeWpf.REST;
using IncommChallengeWpf.DataTypes;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAccounts()
        {
            var api = new IncommApi();
            var result = api.GetAccounts().Result;
            var expected = new IncommAcct("KZ0gJiOPlGRWRI6YYfms", "", 0);
            Assert.AreEqual(result.FirstOrDefault(), expected);
        }

        [TestMethod]
        public void TestTransactions()
        {
            var api = new IncommApi();
            var result = api.GetTransactionss("KZ0gJiOPlGRWRI6YYfms").Result;
            var expected = new IncommTransactions("YonSa7aYjWI1MNzwENgX", "gmzohhd7mcrc56xuijua", "debit", "posted", "test", 500, "09/11/2001 19:50:16");
            bool areEqual = result.Equals(expected);
            Assert.AreEqual(result.FirstOrDefault(), expected);
        }
    }
}
