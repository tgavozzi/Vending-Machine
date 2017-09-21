using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class ReturnChangeTests
    {
        [TestMethod]
        public void WillItReturnChange()
        {
            VendingMachine test = new VendingMachine();
            test.FeedMoney(100);
            test.ReturnChange();
            Assert.AreEqual(0, test.CurrentBalance);


        }
    }
}
