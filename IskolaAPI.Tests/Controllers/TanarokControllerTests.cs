using Microsoft.VisualStudio.TestTools.UnitTesting;
using IskolaAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IskolaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace IskolaAPI.Controllers.Tests
{
    [TestClass()]
    public class TanarokControllerTests
    {
        // A tesztek sorrendje a metódus neve alapján,
        // ABC sorrendben van

        private TanarokController controller = new TanarokController(new iskolaContext());

        private tanarok GetPeldaTanar()
        {
            return new tanarok()
            {
                id = 2,
                nev = "Boros Bence",
                email = "boros.bence@vasvari.org",
                tantargy = "C#"
            };
        }

        private tanarok CreateTestTanar()
        {
            return new tanarok()
            {
                nev = "Teszt Elek",
                email = "elek@teszt.hu",
                tantargy = "Tesztelés"
            };
        }

        // GET: api/Tanarok
        [TestMethod("Darabszám ellenõrzése")]
        public async Task GetTanarok_DarabszamMegfelel()
        {
            // Http Response üzenet
            var response = await controller.Gettanarok();
            // IEnumerable a válasz
            var result = response.Value;
            // Listává alakítjuk
            var result2 = response?.Value as List<tanarok>;

            int szamlalo = 14;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), szamlalo);
            Assert.AreEqual(result2?.Count, szamlalo);
        }

        // GET: api/Tanarok/2, Válasz ID ellenőrzése
        [TestMethod("Válasz ID ellenőrzése")]
        [DataRow(1, DisplayName = "1")]
        [DataRow(2, DisplayName = "2")]
        [DataRow(3, DisplayName = "3")]
        public async Task GetTanar_ValaszUgyanazonNevvel(int id)
        {
            // ez lesz az összeshasonlítási alap
            var response = await controller.Gettanarok(id);
            var tanar = response.Value;

            Assert.IsNotNull(tanar);
            Assert.AreEqual(id, tanar.id);
        }

        // POST: api/Tanarok, Konfliktus ellenõrzése
        [TestMethod("Konfliktus ellenõrzése")]
        public async Task PostTanar_KonfliktusValasszal()
        {
            var tanar = GetPeldaTanar();
            var response = await controller.Posttanarok(tanar);
            // konfliktus válasz típussá átalakítás
            var result = response.Result as ConflictObjectResult;

            Assert.IsNotNull(result);
            // Típus ellenõrzése a példánynak
            Assert.IsInstanceOfType(result, typeof(ConflictObjectResult));
            // 409-es, Conflict státuszkód összehasonlítás
            Assert.AreEqual(result.StatusCode, 409);
        }

        // POST: api/Tanarok, Ugyanazt a válaszértéket kapjuk vissza
        [TestMethod("Ugyanazt a válaszértéket kapjuk vissza")]
        public async Task PostTanar_UgyanazonErtekkel()
        {
            var tanar = CreateTestTanar();
            // Elõször létrehozzuk a tanárt
            var response = await controller.Posttanarok(tanar);
            var result = response.Result as CreatedAtActionResult;
            // A válasz által visszaadott tanár
            var valaszTanar = result?.Value as tanarok;

            Assert.IsNotNull(result);
            // Melyik útvonalon lehet majd lekérdezni
            Assert.AreEqual(result.ActionName, "Gettanarok");
            // A Gettanarok/id útvonalon lesz elérhetõ
            Assert.AreEqual(result?.RouteValues?["id"], valaszTanar?.id);
            // A létrehozott tanár neve megegyezik, az elküldöttel
            Assert.AreEqual(valaszTanar?.nev, tanar.nev);

            // Töröljük az adatbázisból
            await controller.Deletetanarok(valaszTanar.id);
        }

        // PUT: api/Tanarok/999, Hiba eltérõ ID esetén
        [TestMethod("Hiba eltérõ ID esetén")]
        [DataRow(999)]
        public async Task PutTanar_HibaElteroIDnal(int id)
        {
            // a példa ID-ra küldöm a 2-es ID-jú tanár adatait
            var response = await controller.Puttanarok(id, GetPeldaTanar());
            Assert.IsInstanceOfType(response, typeof(BadRequestResult));

            // Itt konvertálás is történik
            var result = response as BadRequestResult;
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        // DELETE: api/Tanarok/id, Státuszkód válasszal
        [TestMethod("Státuszkód válasszal")]
        public async Task DeleteTanar_StatuszKodValasszal()
        {
            var tanar = CreateTestTanar();
            // Elõször létrehozzuk a tanárt
            var postResponse = await controller.Posttanarok(tanar);
            var postResult = postResponse.Result as CreatedAtActionResult;
            // A válasz által visszaadott tanár
            var valaszTanar = postResult?.Value as tanarok;

            var response = await controller.Deletetanarok(valaszTanar.id);
            var result = response as StatusCodeResult;

            Assert.IsNotNull(result);
            // 204, NoContent státuszkód ellenõrzése
            Assert.AreEqual(result.StatusCode, 204);
        }
    }
}