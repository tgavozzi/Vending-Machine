using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class PurchaseTests
    {
        [TestMethod]
        public void DoesCorrectPurchaseReturnItem()
        {
            VendingMachine test = new VendingMachine();
            test.FeedMoney(10000);
            Assert.AreEqual("Potato Crisps", test.GetItemAtSLot("A1").ItemName);
        }

        [TestMethod]
        public void DoesPurchaseLowerCurrentBalance()
        {
            VendingMachine test = new VendingMachine();
            test.FeedMoney(400);
            test.Purchase("A1");
            Assert.AreEqual(95, test.CurrentBalance);
        }

       
    }
}
