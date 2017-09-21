using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class InventoryFileDALTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            InventoryFileDAL test = new InventoryFileDAL();
            Dictionary<string, List<VendingMachineItem>> line = test.GetInventory();
            Assert.AreEqual(16, line.Count);
        }
    }
}
