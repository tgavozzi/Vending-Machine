using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;


namespace CapstoneTests
{
    [TestClass]
    public class FeedMoneyTests
    {
        [TestMethod]
        public void FeedMoneyTest()
        {
            VendingMachine test = new VendingMachine();
            test.FeedMoney(100);
            Assert.AreEqual(100, test.CurrentBalance);

        }
    }
}
