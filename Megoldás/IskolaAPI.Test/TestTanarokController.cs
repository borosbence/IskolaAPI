using IskolaAPI.Controllers;
using IskolaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IskolaAPI.Test
{
    [TestClass]
    public class TestTanarokController
    {
        private TanarokController controller = new TanarokController(new iskolaContext());
        private tanarok GetPeldaTanar()
        {
            return new tanarok() {
                id = 2, nev = "Boros Bence",
                email = "boros.bence@vasvari.org", tantargy = "C#" 
            };
        }
        private tanarok CreateTesztTanar()
        {
            return new tanarok()
            {
                nev = "Teszt Elek",
                email = Guid.NewGuid().ToString(),
                tantargy = "teszt"
            };
        }

        [TestMethod]
        // GET Tanárok, Darabszám megfelelő
        public async Task GetTanarok_DarabszamMegfelel()
        {
            var response = await controller.Gettanarok();
            var result = response.Value;
            var result2 = response.Value as List<tanarok>;

            Assert.IsNotNull(result);
            int szamlalo = 13; // ennyi tanár van a DB-ben
            Assert.AreEqual(result.Count(), szamlalo);
            Assert.AreEqual(result2.Count, szamlalo);
        }

        [TestMethod]
        // GET Tanár, Válasz ugyanazon névvel
        public async Task GetTanar_ValaszUgyanazonNevvel()
        {
            var tanar = GetPeldaTanar();
            // ID alapján lekérdezés
            var response = await controller.Gettanarok(2);
            var result = response.Value;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.nev, tanar.nev);
        }

        [TestMethod]
        // POST Tanár, Konfliktus eredményel
        public async Task PostTanar_KonfliktusValasszal()
        {
            var tanar = GetPeldaTanar();
            var response = await controller.Posttanarok(tanar);
            var result = response.Result as ConflictObjectResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ConflictObjectResult));
            // 409-es státuszkód
            Assert.AreEqual(result.StatusCode, 409);
        }

        [TestMethod]
        // POST Tanár, Ugyanazon visszatérési értékkel
        public async Task PostTanar_UgyanazonErtekkel()
        {
            // véletlenszerű adatok a konfliktus elkerüléséhez
            var tanar = CreateTesztTanar();
            // tanár létrehozása
            var response = await controller.Posttanarok(tanar);
            var result = response.Result as CreatedAtActionResult;
            // válaszüzenet ellenőrzése
            var valaszTanar = result.Value as tanarok;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.ActionName, "Gettanarok");
            Assert.AreEqual(result.RouteValues["id"], valaszTanar.id);
            Assert.AreEqual(valaszTanar.email, tanar.email);

            // létrehozott tanár törlése
            await controller.Deletetanarok(valaszTanar.id);
        }

        [TestMethod]
        // PUT Tanár, Hiba eltérő ID esetén
        public async Task PutTanar_HibaElteroIDnal()
        {
            // 999 ID-jű, nem létező tanár módosítása
            var response = await controller.Puttanarok(999, GetPeldaTanar());
            Assert.IsInstanceOfType(response, typeof(BadRequestResult));

            // konvertálással
            var result = response as BadRequestResult;
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        // DELETE Tanár, Státuszkód válasszal
        public async Task DeleteTanar_StatuszkodValasszal()
        {
            var tanar = CreateTesztTanar();
            // tanár létrehozása a törléshez
            var postResponse = await controller.Posttanarok(tanar);
            var postResult = postResponse.Result as CreatedAtActionResult;
            var letrehozottTanar = postResult.Value as tanarok;
            // tanár törlése
            var response = await controller.Deletetanarok(letrehozottTanar.id);
            var result = response as StatusCodeResult;

            Assert.IsNotNull(result);
            // 204-es státuszkód
            Assert.AreEqual(result.StatusCode, 204);
        }
    }
}
