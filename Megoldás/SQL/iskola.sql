-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2021. Okt 18. 19:04
-- Kiszolgáló verziója: 10.4.21-MariaDB
-- PHP verzió: 7.4.23

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `iskola`
--
CREATE DATABASE IF NOT EXISTS `iskola` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `iskola`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `diakok`
--

CREATE TABLE `diakok` (
  `id` int(11) NOT NULL,
  `nev` varchar(50) NOT NULL,
  `email` varchar(22) NOT NULL,
  `erdemjegy` smallint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `diakok`
--

INSERT INTO `diakok` (`id`, `nev`, `email`, `erdemjegy`) VALUES
(1, 'Balogh Norbert', 'sze0balnor@vasvari.org', 5),
(2, 'Csamangó Janka', 'sze0csajan@vasvari.org', 2),
(3, 'Dialló Ahmadou Costidor', 'sze0diaahm@vasvari.org', 3),
(4, 'Fehérné Balogh Katalin Ágnes', 'sze0fehbal@vasvari.org', 2),
(5, 'Horváth Alexandra Nikolett', 'sze0horale@vasvari.org', 5),
(6, 'Imrő-Bárkányi Erika', 'sze0bareri@vasvari.org', 3),
(7, 'Katona Tamás', 'sze0kattam@vasvari.org', 4),
(8, 'Kovács Fruzsina Réka', 'sze0kovfru@vasvari.org', 1),
(9, 'Nagy Anna Viola', 'sze0nagann@vasvari.org', 1),
(10, 'Nagy György', 'sze0naggyo@vasvari.org', 3),
(11, 'Oláh Dániel', 'sze0oladan@vasvari.org', 3),
(12, 'Papp Martin', 'sze0papmar@vasvari.org', 1),
(13, 'Szabácsi Noémi', 'sze0szanoe@vasvari.org', 1),
(14, 'Szekeres Dániel Imre', 'sze0szedan@vasvari.org', 4),
(15, 'Tápai Nándor', 'sze0tapnan@vasvari.org', 4),
(16, 'Toldi Richárd', 'sze0tolric@vasvari.org', 1),
(17, 'Trescsula Márk', 'sze0tremar@vasvari.org', 5),
(18, 'Gardi Erik János', 'sze0gareri@vasvari.org', 5),
(19, 'Radóc Dávid', 'sze0raddav@vasvari.org', 2),
(20, 'Boros Bence', 'bence@vasvari.org', 4);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `tanarok`
--

CREATE TABLE `tanarok` (
  `id` int(11) NOT NULL,
  `nev` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `tantargy` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `tanarok`
--

INSERT INTO `tanarok` (`id`, `nev`, `email`, `tantargy`) VALUES
(1, 'Bálint Róbert', 'balint.robert@vasvari.org', 'Webprogramozás'),
(2, 'Boros Bence', 'boros.bence@vasvari.org', 'C#'),
(3, 'Csontos Péter', 'csontos.peter@vasvari.org', 'C#'),
(4, 'Dr. Nyári Tibor', 'nyari.tibor@vasvari.org', 'Szoftvertesztelés'),
(5, 'Fanaczán János', 'fanaczan@vasvari.org', 'Játékfejlesztés'),
(6, 'Gyarmat Zsolt', 'gyarmat.zsolt@vasvari.org', 'Webprogramozás'),
(7, 'Gyuris Csaba', 'gyuris.csaba@vasvari.org', 'C#'),
(8, 'Kádár Tünde', 'kadar.tunde@vasvari.org', 'Adatbázis'),
(9, 'Molnár Edit', 'molnar.edit@vasvari.org', 'Webprogramozás'),
(10, 'Pap Zoltán', 'pap.zoltan@vasvari.org', 'Python'),
(11, 'Rédai Dávid', 'redai.david@vasvari.org', 'Java'),
(12, 'Szilágyi Zoltán', 'szilagyi.zoltan@vasvari.org', 'Hálózati alapok'),
(13, 'Vastag Atila', 'vastag.atila@vasvari.org', 'Mobilalkalmazás');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `vezetoseg`
--

CREATE TABLE `vezetoseg` (
  `id` int(11) NOT NULL,
  `nev` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `megbizas` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `vezetoseg`
--

INSERT INTO `vezetoseg` (`id`, `nev`, `email`, `megbizas`) VALUES
(1, 'Sutka Irén', 'sutka.iren@vasvari.org', 'igazgató'),
(2, 'Dóka Zoltán Béla', 'doka.zoltan@vasvari.org', 'általános igazgatóhelyettes'),
(3, 'Király-Török Annamária', 'kiraly.annamaria@vasvari.org', 'pedagógiai igazgatóhelyettes'),
(4, 'Molnár Edit', 'molnar.edit@vasvari.org', 'szakmai igazgatóhelyettes');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `diakok`
--
ALTER TABLE `diakok`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `nev` (`nev`);

--
-- A tábla indexei `tanarok`
--
ALTER TABLE `tanarok`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`);

--
-- A tábla indexei `vezetoseg`
--
ALTER TABLE `vezetoseg`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`,`email`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `diakok`
--
ALTER TABLE `diakok`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT a táblához `tanarok`
--
ALTER TABLE `tanarok`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT a táblához `vezetoseg`
--
ALTER TABLE `vezetoseg`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
