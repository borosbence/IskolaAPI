using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        [TestCategory("Adatbázis")]
        [TestMethod("Adatbázis elérés teszt")]
        public void DbConnectionTest()
        {
            var context = new iskolaContext();
            bool canConnect = context.Database.CanConnect();
            Assert.IsTrue(canConnect);
        }
    }
}