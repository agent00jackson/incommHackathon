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
    }
}
