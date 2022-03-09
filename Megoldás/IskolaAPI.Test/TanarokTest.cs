using IskolaAPI.Controllers;
using IskolaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace IskolaAPI.Test
{
    [TestClass]
    public class TestProductController
    {
        private tanarok GetPeldaTanar()
        {
            return new tanarok() { id = 2, nev = "Boros Bence", email = "boros.bence@vasvari.org", tantargy = "C#" };
        }

        [TestMethod]
        public async Task PostTanar_MarLetezik()
        {
            var controller = new TanarokController(new iskolaContext());

            var tanar = GetPeldaTanar();

            var response = await controller.Posttanarok(tanar);
            var result = response.Result as ConflictObjectResult;

            Assert.AreEqual(result.StatusCode, 409);
        }
    }
}
