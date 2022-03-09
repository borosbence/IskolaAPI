# IskolaAPI
C# Web API Iskola modelhez.

**Diákok létrehozása:**

A Vasvári Pál szoftverfejlesztő diákjai beadandót készítenek C# órára. A javító tanár számára készítsünk egy egyszerű C# Web API-t, hogy megkönnyítsük a munkáját. Forrásként használja a *2/14.be.xls* fájlt!

1. A szakmai tanár csoportvezetőnek szüksége van az osztály létszámára az órarend készítéshez.
Számolja ki, hogy hány diák szerepel az osztályban!
2. Az igazgatóhelyettes számon fogja kérni a javítandó tanárt, hogy számoljon be az osztályátlagról, milyen lett a diákok eddigi teljesítménye.
Készítse el az átlagot kiszámító metódust!
3. Az Oktatási Hivatal idén a 2/14. osztályt jelölte ki megfigyelésre. Szeretnék tudni, hogy érdemjegyek alapján mennyire teljesített jól az osztály.
Csoportosítsa az osztályt érdemjegy alapján, majd számolja ki, hogy az egyes érdemjegyekből mennyi jegy született.
4. A tanár szeretne még egy esélyt adni azoknak a diákoknak, akiknek nem sikerült jól a dolgozatuk (1-est kaptak). 
Szedje össze azoknak a diákok email címét, akik megbuktak.
5. Új diák hozzáadásánál ellenőrizze, hogy már létezik-e a diák, ha igen akkor adjon vissza egy konfliktusra vonatkozó státusz üzenetet.
6. Frissítse a saját érdemjegyét egy tetszőleges érdemjegyre (lehet, akár 6-os is).

**Iskola bővítése:**

1. Hozzon létre a meglévő adatbázisba még kéttáblát:

tanarok:
- id: int(11), PRIMARY, AI
- nev: varchar(50)
- email: varchar(50), UNIQUE
- tantargy: varchar(20)

vezetoseg:
- id: int(11), PRIMARY, AI
- nev: varchar(50)
- email: varchar(50), UNIQUE
- megbizas: varchar(50)

2. Importálja be a *vezetőség.xlsx* és az *infotanárok.xlsx* fájlt a megfelelő táblákba!
3. Futtassa le a Package Manager Console-on a Scaffold-DBContext parancsot, a mellékelt *pm_commands.txt* fájl alapján!
4. A legenerált modellek után, hajtson végre a projekten egy Build-et! (Ctrl+Shift+B)
5. A projekhez hozzon létre egy Tanarok és egy Vezetoseg Controller osztályt, amiket a táblához köt a varázsló segítségével.
6. Tesztelje az api/Tanarok, api/Vezetoseg útvonalon létrejött Web API interfészt.
