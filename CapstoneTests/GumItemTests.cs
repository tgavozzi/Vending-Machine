using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class GumItemTests
    {
        [TestMethod]
        public void GumNameTest()
        {
            GumItem gum = new GumItem("Tuttie Fruttie", 1.50M);

            Assert.AreEqual("Tuttie Fruttie", gum.itemName);
        }

        [TestMethod]
        public void GumPriceTest()
        {
            GumItem gum = new GumItem("Tuttie Fruttie", 1.50M);

            Assert.AreEqual(150M, gum.priceInCents);
        }

        [TestMethod]
        public void GumConsumeTest()
        {
            GumItem gum = new GumItem("Tuttie Fruttie", 1.50M);

            Assert.AreEqual("Chew Chew, Yum!", gum.Consume());
        }
    }
}

