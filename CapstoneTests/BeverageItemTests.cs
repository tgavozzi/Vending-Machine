using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class BeverageItemTests
    {
        [TestMethod]
        public void BeverageNameTest()
        {
            BeverageItem pop = new BeverageItem("Dr. Pepper", 1.50M);

            Assert.AreEqual("Dr. Pepper", pop.itemName);
        }

        [TestMethod]
        public void BeveragePriceTest()
        {
            BeverageItem pop = new BeverageItem("Dr. Pepper", 1.50M);

            Assert.AreEqual(150M, pop.priceInCents);
        }

        [TestMethod]
        public void BeverageConsumeTest()
        {
            BeverageItem pop = new BeverageItem("Dr. Pepper", 1.50M);
            
            Assert.AreEqual("Glug Glug, Yum!", pop.Consume());
        }
    }
}
