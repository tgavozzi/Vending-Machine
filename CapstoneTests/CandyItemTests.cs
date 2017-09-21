using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class CandyItemTests
    {
        [TestMethod]
        public void CandyNameTest()
        {
            CandyItem chocolate = new CandyItem("Crunch", 1.50M);

            Assert.AreEqual("Crunch", chocolate.itemName);
        }

        [TestMethod]
        public void CandyPriceTest()
        {
            CandyItem chocolate = new CandyItem("Crunch", 1.50M);

            Assert.AreEqual(150M, chocolate.priceInCents);
        }

        [TestMethod]
        public void CandyConsumeTest()
        {
            CandyItem chocolate = new CandyItem("Crunch", 1.50M);

            Assert.AreEqual("Munch Munch, Yum!", chocolate.Consume());
        }
    }
}

