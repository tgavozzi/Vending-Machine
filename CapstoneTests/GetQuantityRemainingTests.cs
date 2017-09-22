using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class GetQuantityRemainingTests
    {
        [TestMethod]
        public void QuantityToStartIs5()
        {
            VendingMachine test = new VendingMachine();
            Assert.AreEqual(5, test.GetQuantityRemaining("A1"));
        }
    }
}
