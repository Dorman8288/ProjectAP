using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectAP.Sources;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectAP.Sources.Tests
{
    [TestClass()]
    public class AccountTests
    {
        [TestMethod()]
        public void CardIsValidTest()
        {
            Account a = new Account();
            Assert.AreEqual(true, a.CardIsValid();
            Assert.AreEqual(true, a.CardIsValid();
            Assert.AreEqual(true, a.CardIsValid();
        }
    }
}