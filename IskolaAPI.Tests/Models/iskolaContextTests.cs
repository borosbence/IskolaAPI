using Microsoft.VisualStudio.TestTools.UnitTesting;
using IskolaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IskolaAPI.Models.Tests
{
    [TestClass()]
    public class iskolaContextTests
    {
        [TestMethod()]
        public void DbConnectionTest()
        {
            var context = new iskolaContext();
            bool canConnect = context.Database.CanConnect();
            Assert.IsTrue(canConnect);
        }
    }
}