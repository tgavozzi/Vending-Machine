using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class ChipItemTests
    {
        [TestMethod]
        public void ChipNameTest()
        {
            ChipItem chips = new ChipItem("Lays", 1.50M);

            Assert.AreEqual("Lays", chips.itemName);
        }

        [TestMethod]
        public void CandyPriceTest()
        {
            ChipItem chips = new ChipItem("Lays", 1.50M);

            Assert.AreEqual(150M, chips.priceInCents);
        }

        [TestMethod]
        public void CandyConsumeTest()
        {
            ChipItem chips = new ChipItem("Lays", 1.50M);

            Assert.AreEqual("Crunch Crunch, Yum!", chips.Consume());
        }
    }
}
