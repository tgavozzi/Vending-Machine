using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class Change35CentTests
    {
        [TestMethod]
        public void Will35CentRenturn1QAnd1Dime()
        {
            Change thirtyFive = new Change(35);

            Assert.AreEqual(1, thirtyFive.Quarters);
            Assert.AreEqual(1, thirtyFive.Dimes);
        }

        [TestMethod]
        public void WillOneDollar65CentsCentRenturn1QAnd1Dime()
        {
            Change one65 = new Change(1.65M);

            Assert.AreEqual(6, one65.Quarters);
            Assert.AreEqual(1, one65.Dimes);
            Assert.AreEqual(1, one65.Nickels);
        }
    }
}
